using GenericDB.Control;
using GenericDB.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace GenericDB.DAO
{
    /// <summary>
    /// Classe de Objeto de Acesso a Dados Genérica, responsável por persistir dados de um objeto ao banco de dados.
    /// </summary>
    class GenericTDAO : IGeneric
    {
        private Database db;
        /// <summary>
        /// Construtor da classe que quando instanciada atribui a instancia da Database na váriavel Database
        /// dentro da própria classe para obter o gerenciamento da conexão.
        /// </summary>
        public GenericTDAO()
        {
            db = Database.GetInstance();
        }

        /// <summary>
        /// Método de inserção de um objeto genérico do tipo "T" que recebe esse objeto de qualquer classe e chama outro
        /// método da classe Database passando o objeto e um enumerador do tipo da query sql que será executada. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        public void Insert<T>(T ob)
        {
            db.ExecuteNonQuery(db.buildQuery(ob, QueryType.INSERT));
        }

        /// <summary>
        /// Método de remoção de um objeto genérico do tipo "T" que recebe esse objeto de qualquer classe e chama outro
        /// método da classe Database passando o objeto e um enumerador do tipo da query sql que será executada.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        public void Remove<T>(T ob)
        {
            db.ExecuteNonQuery(db.buildQuery(ob, QueryType.DELETE));
        }

        /// <summary>
        /// Método de atualização de um objeto genérico do tipo "T" que recebe esse objeto de qualquer classe e chama outro
        /// método da classe Database passando o objeto e um enumerador do tipo da query sql que será executada.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ob"></param>
        public void Update<T>(T ob)
        {
            db.ExecuteNonQuery(db.buildQuery(ob, QueryType.UPDATE));
        }

        /// <summary>
        /// Método que retorna o número da próxima sequência do autoincrement do sqlite dada uma classe genérica qualquer.
        /// </summary>
        /// <returns></returns>
        public int nextSequence()
        {
            StringBuilder qry = new StringBuilder();
            string typeClassDAO = this.GetType().Name.ToUpper();
            string typeClass = typeClassDAO.Replace("DAO","");
            qry.Append("SELECT seq FROM sqlite_sequence WHERE name like '"+ typeClass.ToUpper() +"';");
            DataSet ds = db.ExecuteQuery(qry.ToString());
            int seq = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
                seq = int.Parse(dr["seq"].ToString());
            seq++;
            return seq;
        }
    }
}
