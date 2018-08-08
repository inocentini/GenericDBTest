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
    class Database
    {
        private static SQLiteConnection connection;
        private static Database instance;
        private const string URL = "Data Source=database.db";
        private const string NOMEBANCO = "database.db";

        public Database()
        {
            connection = new SQLiteConnection(URL);
            if (!File.Exists(NOMEBANCO))
            {
                SQLiteConnection.CreateFile(NOMEBANCO);
                SQLiteConnection connection = new SQLiteConnection(URL);
                connection.Open();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("CREATE TABLE IF NOT EXISTS PESSOA([id] INTEGER PRIMARY KEY AUTOINCREMENT,[cpf] VARCHAR(32),[nome] VARCHAR(64));");
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

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        public void ExecuteNonQuery(string qry)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(qry, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void ExecuteNonQuery(SQLiteCommand cmd)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public DataSet ExecuteQuery(string qry)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand cmd = new SQLiteCommand(qry, connection);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            connection.Close();
            return ds;
        }

    }
}
