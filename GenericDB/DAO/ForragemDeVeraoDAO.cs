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
    class ForragemDeVeraoDAO : GenericTDAO
    {
        Database db;
        public ForragemDeVeraoDAO()
        {
            db = Database.GetInstance();
        }


        public List<ForragemDeVerao> ListAll()
        {
            String query = String.Format("SELECT * FROM FORRAGEMDEVERAO");
            DataSet ds = db.ExecuteQuery(query);

            List<ForragemDeVerao> lista = new List<ForragemDeVerao>();
            foreach (DataRow dr in ds.Tables[0].Rows)
                lista.Add(new ForragemDeVerao { Id = int.Parse(dr["id"].ToString()), Desc = dr["desc"].ToString(), Qnt = int.Parse(dr["qnt"].ToString()), Preco = double.Parse(dr["preco"].ToString()) });
            return lista;
        }

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
