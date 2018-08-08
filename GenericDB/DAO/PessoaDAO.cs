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
    class PessoaDAO : GenericDAO
    {

        public List<Pessoa> ListAll()
        {
            Database db = Database.GetInstance();
            String query = String.Format("SELECT * FROM Pessoa");
            DataSet ds = db.ExecuteQuery(query);
            
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                pessoas.Add(new Pessoa {Id = dr["id"].ToString(), Cpf = dr["cpf"].ToString(), Nome = dr["nome"].ToString() });
            }
            return pessoas;
        }

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
