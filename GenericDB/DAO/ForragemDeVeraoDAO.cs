using GenericDB.Model;
using GenericDB.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.DAO
{
    /// <summary>
    /// Classe de Objeto de Acesso a Dados da classe modelo ForragemDeVerão, responsável por persistir um objeto ao banco de dados
    /// </summary>
    class ForragemDeVeraoDAO : GenericTDAO
    {
        Database db;

        /// <summary>
        /// Construtor da classe que quando instanciada atribui a instancia da Database na váriavel Database
        /// dentro da própria classe para obter o gerenciamento da conexão.
        /// </summary>
        public ForragemDeVeraoDAO()
        {
            db = Database.GetInstance();
        }

        /// <summary>
        /// Método de listar todos os objetos inseridos no banco de dados, retorna uma lista de ForragemDeVerao
        /// </summary>
        /// <returns></returns>
        public List<ForragemDeVerao> ListAll()
        {
            String query = String.Format("SELECT * FROM FORRAGEMDEVERAO");
            DataSet ds = db.ExecuteQuery(query);

            List<ForragemDeVerao> lista = new List<ForragemDeVerao>();
            foreach (DataRow dr in ds.Tables[0].Rows)
                lista.Add(new ForragemDeVerao { Id = int.Parse(dr["id"].ToString()), Desc = dr["desc"].ToString(), Qnt = int.Parse(dr["qnt"].ToString()), Preco = double.Parse(dr["preco"].ToString()) });
            return lista;
        }

        /// <summary>
        /// Método que lê apenas um objeto ja inserido no banco de dados dado um id como um parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ForragemDeVerao Read(int id) {
            String query = String.Format("SELECT * FROM FORRAGEMDEVERAO WHERE id= '{0}'", id);
            DataSet ds = db.ExecuteQuery(query);

            ForragemDeVerao fv = new ForragemDeVerao();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                fv.Id = int.Parse(dr["id"].ToString());
                fv.Desc = dr["desc"].ToString();
                fv.Qnt = int.Parse(dr["qnt"].ToString());
                fv.Preco = double.Parse(dr["preco"].ToString());
            }
            return fv;
        }
       
    }
}
