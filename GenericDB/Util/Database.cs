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
    /// <summary>
    /// Classe de gerenciamento de conexão ao Banco de Dados
    /// </summary>
    class Database
    {
        /// Atributos
        private static SQLiteConnection connection; 
        private static Database instance;
        private const string URL = "Data Source=database.db";
        private const string NOMEBANCO = "database.db";


        /// <summary>
        /// Construtor da classe Database, verifica se o arquivo do banco está criado senão ele o cria bd com suas respectivas tabelas e faz sua conexão
        /// </summary>
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

        /// <summary>
        /// Método que retorna a instancia do Banco para pegar a conexão
        /// </summary>
        /// <returns></returns>
        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        /// <summary>
        /// Método que retorna a conexão com o BD
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            return connection;
        }

        /// <summary>
        /// Método de que dado uma query como parâmetro executa uma query sql no BD.
        /// </summary>
        /// <param name="qry"></param>
        public void ExecuteNonQuery(string qry)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(qry, connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }


        /// <summary>
        /// Método que dado um SQLiteCommand como parâmetro executa uma query sql no BD.
        /// </summary>
        /// <param name="cmd"></param>
        public void ExecuteNonQuery(SQLiteCommand cmd)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            cmd.Connection = connection;
            cmd.ExecuteNonQuery();

            connection.Close();
        }


        /// <summary>
        /// Método que dado uma query como parâmetro executa e armazena o valor de uma query sql no BD.
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Método que constrói uma query sql dado um objeto genérico do tipo "T" e um enumerador para saber o tipo de query sql que será construida.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public SQLiteCommand buildQuery<T>(T ob, QueryType q)
        {
            Type type = ob.GetType();
            PropertyInfo[] attrs = ob.GetType().GetProperties();
            StringBuilder query = new StringBuilder();
            SQLiteCommand cmd = new SQLiteCommand();

            switch (q)
            {
                case QueryType.INSERT:

                    query.Append("INSERT INTO " + ob.GetType().Name.ToUpper() + "(");

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


                    cmd = new SQLiteCommand(query.ToString());

                    foreach (var atts in attrs)
                        cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                    return cmd;

                case QueryType.DELETE:

                    query = new StringBuilder();
                    query.Append("DELETE " + ob.GetType().Name.ToUpper() + " WHERE " + attrs[0].Name.ToLower() + "=@" + attrs[0].Name.ToLower());

                     cmd = new SQLiteCommand(query.ToString());

                    foreach (var atts in attrs)
                        cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                    return cmd;

                case QueryType.UPDATE:

                    query = new StringBuilder();
                    query.Append("UPDATE " + ob.GetType().Name.ToUpper() + " SET ");

                    for (int i = 0; i < attrs.Length - 1; i++)
                    {
                        query.Append(attrs[i].Name.ToLower() + "=@" + attrs[i].Name.ToLower() + ", ");

                    }
                    query.Append(attrs[attrs.Length - 1].Name.ToLower() + "=@" + attrs[attrs.Length - 1].Name.ToLower() + " WHERE " + attrs[0].Name.ToLower() + " =@" + attrs[0].Name.ToLower());

                    cmd = new SQLiteCommand(query.ToString());

                    foreach (var atts in attrs)
                        cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name.ToLower(), atts.GetValue(ob)));
                    return cmd;

            }

            return null;
        }

    }

    /// <summary>
    /// Enumarador de tipo de query SQL.
    /// </summary>
    public enum QueryType {
        INSERT,
        UPDATE,
        DELETE,
        READ,
        LIST
    }
}
