using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
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
                sql.AppendLine("CREATE TABLE IF NOT EXISTS FORRAGEMDEVERAO([id] INTEGER PRIMARY KEY AUTOINCREMENT, [desc] VARCHAR(64), [qnt] INTEGER,[preco] REAL);");
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

        public SQLiteCommand buildQuery<T>(T ob, string qry)
        {
            Type type = ob.GetType();
            PropertyInfo[] attrs = ob.GetType().GetProperties();

            if (qry.Equals("INSERT INTO "))
            {
                StringBuilder query = new StringBuilder();
                query.Append(qry + ob.GetType().Name.ToUpper() + "(");

                for (int i = 0; i < attrs.Length - 1; i++)
                {
                    query.Append(attrs[i].Name.ToLower() + ", ");

                }
                query.Append(attrs[attrs.Length - 1].Name.ToLower() + ") VALUES(");


                for (int i = 0; i < attrs.Length - 1; i++)
                {
                    query.Append("@" + attrs[i].Name.ToLower() + ", ");
                }
                query.Append("@" + attrs[attrs.Length - 1].Name.ToLower() + ");");


                SQLiteCommand cmd = new SQLiteCommand(query.ToString());

                foreach (var atts in attrs)
                    cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                return cmd;
            }
            else if (qry.Equals("DELETE FROM "))
            {
                StringBuilder query = new StringBuilder();
                query.Append(qry + ob.GetType().Name.ToUpper() + " WHERE " + attrs[0].Name.ToLower() + "=@" + attrs[0].Name.ToLower());

                SQLiteCommand cmd = new SQLiteCommand(query.ToString());

                foreach (var atts in attrs)
                    cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                return cmd;
            }
            else if (qry.Equals("UPDATE "))
            {
                StringBuilder query = new StringBuilder();
                query.Append(qry + ob.GetType().Name.ToUpper() + " SET ");

                for (int i = 0; i < attrs.Length - 1; i++)
                {
                    query.Append(attrs[i].Name.ToLower() + "=@" + attrs[i].Name.ToLower() + ", ");

                }
                query.Append(attrs[attrs.Length - 1].Name.ToLower() + "=@" + attrs[attrs.Length - 1].Name.ToLower() + " WHERE " + attrs[0].Name.ToLower() + " =@" + attrs[0].Name.ToLower());

                SQLiteCommand cmd = new SQLiteCommand(query.ToString());

                foreach (var atts in attrs)
                    cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                return cmd;
            }
           
            return null;
        }

    }
}
