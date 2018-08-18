using GenericDB.Control;
using GenericDB.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.DAO
{
    /// <summary>
    /// Classe de Objeto de Acesso a Dados Genérica com dictionary, responsável por persistir dados de um objeto ao banco de dados.
    /// </summary>
    class GenericDDAO
    {
        private Database db;

        /// <summary>
        /// Construtor da classe que quando instanciada atribui a instancia da Database na váriavel Database
        /// dentro da própria classe para obter o gerenciamento da conexão.
        /// </summary>
        public GenericDDAO()
        {
           db = Database.GetInstance();
        }
        /// <summary>
        /// Método de inserção de um objeto genérico que deve ter implementado a interface IEntity para poder recuperar seus atributos. 
        /// </summary>
        /// <param name="ob"></param>
        public void Insert(IEntity ob)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO " + ob.GetType().Name.ToUpper() + "(");

            for (int i = 0; i < ob.Properties().Keys.Count - 1; i++)
                query.Append(ob.Properties().Keys.ToArray()[i].ToLower() + ", ");
            query.Append(ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1] + ") VALUES (");

            for (int i = 0; i < ob.Properties().Keys.Count - 1; i++)
                query.Append("@" + ob.Properties().Keys.ToArray()[i].ToLower() + ", ");
            query.Append("@" + ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1] + ");");

            SQLiteCommand cmd = new SQLiteCommand(query.ToString());

            foreach (var prop in ob.Properties())
                cmd.Parameters.Add(new SQLiteParameter("@" + prop.Key, prop.Value));

            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Método de atualização de um objeto genérico que deve ter implementado a interface IEntity para poder recuperar seus atributos. 
        /// </summary>
        /// <param name="ob"></param>
        public void Update(IEntity ob)
        {
            StringBuilder query = new StringBuilder();
            query.Append("UPDATE " + ob.GetType().Name.ToUpper() + " SET ");
            for (int i = 0; i < ob.Properties().Keys.Count - 1; i++)
            {
                query.Append(ob.Properties().Keys.ToArray()[i].ToLower() + "= ");
                query.Append("@" + ob.Properties().Keys.ToArray()[i].ToLower() + ", ");
            }
            query.Append(ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1].ToLower() + "= ");
            query.Append("@" + ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1].ToLower() + " WHERE " + ob.Properties().Keys.ToArray()[0].ToLower() +"=");
          

            query.Append("@" + ob.Properties().Keys.ToArray()[0].ToLower()+ ";");

            SQLiteCommand cmd = new SQLiteCommand(query.ToString());

            foreach (var prop in ob.Properties())
                cmd.Parameters.Add(new SQLiteParameter("@" + prop.Key, prop.Value));
            db.ExecuteNonQuery(cmd);
            
             
        }

        /// <summary>
        /// Método de remoção de um objeto genérico que deve ter implementado a interface IEntity para poder recuperar seus atributos. 
        /// </summary>
        /// <param name="ob"></param>
        public void Remove(IEntity ob)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM " + ob.GetType().Name.ToUpper() + " WHERE " + ob.Properties().Keys.ToArray()[0].ToString() + "= @" +  ob.Properties().Keys.ToArray()[0].ToLower());
            SQLiteCommand cmd = new SQLiteCommand(query.ToString());
            foreach (var prop in ob.Properties())
                cmd.Parameters.Add(new SQLiteParameter("@" + prop.Key, prop.Value));
            db.ExecuteNonQuery(cmd);            
        }

    }
}
