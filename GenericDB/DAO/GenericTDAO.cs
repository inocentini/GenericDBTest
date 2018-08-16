﻿using GenericDB.Control;
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
    class GenericTDAO : IGeneric
    {
        private Database db;

        public GenericTDAO()
        {
            db = Database.GetInstance();
        }

        public void Insert<T>(T ob)
        {
            string query = string.Format("INSERT INTO ");
           
            db.ExecuteNonQuery(db.buildQuery(ob, query));

        }

        public void Remove<T>(T ob)
        {
            string query = string.Format("DELETE FROM ");

            db.ExecuteNonQuery(db.buildQuery(ob, query));
        }

        public void Update<T>(T ob)
        {
            string query = string.Format("UPDATE ");
            db.ExecuteNonQuery(db.buildQuery(ob, query));
        }

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