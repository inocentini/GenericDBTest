using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDB.Model;
using GenericDB.Util;
using System.Data;
using System.Data.SQLite;

namespace GenericDB.DAO
{
    /// <summary>
    /// Classe de Objeto de Acesso a Dados da classe modelo Pessoa, responsável por persistir um objeto ao banco de dados
    /// </summary>
    class PessoaDAO : GenericDDAO
    {
        Database db;

        /// <summary>
        /// Construtor da classe que quando instanciada atribui a instancia da Database na váriavel Database
        /// dentro da própria classe para obter o gerenciamento da conexão.
        /// </summary>
        public PessoaDAO()
        {
            db = Database.GetInstance();
        }

        /// <summary>
        /// Método de listar todos os objetos inseridos no banco de dados, retorna uma lista de Pessoa
        /// </summary>
        /// <returns></returns>
        public List<Pessoa> ListAll()
        {
            String query = String.Format("SELECT * FROM Pessoa");
            DataSet ds = db.ExecuteQuery(query);
            
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                pessoas.Add(new Pessoa {Id = dr["id"].ToString(), Cpf = dr["cpf"].ToString(), Nome = dr["nome"].ToString() });
            }
            return pessoas;
        }

        /// <summary>
        /// Método que lê apenas um objeto ja inserido no banco de dados dado um id como parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pessoa Read(int id)
        {
            Database db = Database.GetInstance();
            String query = String.Format("SELECT * FROM Pessoa WHERE id='{0}'", id);
        
            Pessoa p = new Pessoa();   
                     
            DataSet ds = db.ExecuteQuery(query);
            foreach(DataRow dr in ds.Tables[0].Rows){
                p.Id = dr["id"].ToString();
                p.Cpf = dr["cpf"].ToString();
                p.Nome = dr["nome"].ToString();
            }
            return p;
        }


    }
}
