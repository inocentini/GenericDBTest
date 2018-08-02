using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDB.Util
{
    class GenericDatabase : Database
    {
        private static SQLiteConnection connection;
        private static GenericDatabase instance;
        private const string URL = "Data Source=database.db";
        private const string NOMEBANCO = "database.db";

        public GenericDatabase()
        {
            connection = new SQLiteConnection(URL);
            if (!File.Exists(NOMEBANCO))
            {
                SQLiteConnection.CreateFile(NOMEBANCO);
                SQLiteConnection connection = new SQLiteConnection(URL);
                connection.Open();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS Pessoa([id] INTEGER PRIMARY KEY AUTOINCREMENT,[cpf] VARCHAR(32),[nome] VARCHAR(64));");
                SQLiteCommand cmd = new SQLiteCommand(sql.ToString(), connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }catch(Exception e)
                {
                    MessageBox.Show("Erro ao criar banco de dados:" + e.Message);
                }
            }
        }

        public static GenericDatabase GetInstance()
        {
            if (instance == null)
            {
                instance = new GenericDatabase();
            }
            return instance;
        }
    

        public override IDbDataAdapter GetAdapter(IDbCommand command)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            SQLiteCommand cmd = new SQLiteCommand(command.CommandText, connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            
            return da;
        }

        public override IDbCommand GetCommand(string query)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            return new SQLiteCommand(query, connection); 
        }

        public override IDbConnection GetConnection()
        {
            return new SQLiteConnection(connection);
        }

    }
}
