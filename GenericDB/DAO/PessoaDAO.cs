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
    class PessoaDAO : IPessoa
    {

        public void Delete(Pessoa p)
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();

            String query = String.Format("DELETE FROM Pessoa WHERE cpf = '{0}'",p.Cpf);
            gdb.GetCommand(query).ExecuteNonQuery();
            gdb.Close();
            
        }

        public void Insert(Pessoa p)
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();
            String query = String.Format("INSERT INTO Pessoa(cpf,nome) VALUES('{0}','{1}')",p.Cpf,p.Nome);
            gdb.GetCommand(query).ExecuteNonQuery();
            gdb.Close();
        }

        public List<Pessoa> ListAll()
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();
            String query = String.Format("SELECT * FROM Pessoa");
            SQLiteDataAdapter da = (SQLiteDataAdapter) gdb.GetAdapter(gdb.GetCommand(query));   
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            
            List<Pessoa> pessoas = new List<Pessoa>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                pessoas.Add(new Pessoa { Cpf = dr["cpf"].ToString(), Nome = dr["nome"].ToString() });
            }
            return pessoas;
        }

        public Pessoa Read(int id)
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();
            String query = String.Format("SELECT * FROM Pessoa WHERE cpf='{0}'", id);
            SQLiteCommand cmd = (SQLiteCommand)gdb.GetCommand(query) ;
            SQLiteDataReader dr = cmd.ExecuteReader();
            Pessoa p = new Pessoa();
            while (dr.Read())
            {
                p.Cpf = dr["cpf"].ToString();
                p.Nome = dr["nome"].ToString();
            }
            return p;
        }

        public void Update(Pessoa p)
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();
            String query = String.Format("UPDATE Pessoa SET nome = '{0}' WHERE cpf={1}", p.Nome, p.Cpf);
            gdb.GetCommand(query).ExecuteNonQuery();
            gdb.Close();
        }
    }
}
