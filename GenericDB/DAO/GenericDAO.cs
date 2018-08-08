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
    class GenericDAO
    {
        private Database db;
        public GenericDAO()
        {
           db = Database.GetInstance();
        }

        public void Insert(IEntity ob)        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO " + ob.GetType().Name.ToUpper() + "(");
             
            for(int i =0; i<ob.Properties().Keys.Count -1; i++)
                query.Append(ob.Properties().Keys.ToArray()[i].ToLower() + ", ");
            query.Append(ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1] + ") VALUES (");

            for (int i = 0; i < ob.Properties().Keys.Count - 1; i++)
                query.Append("@" + ob.Properties().Keys.ToArray()[i].ToLower() + ", ");
            query.Append("@" + ob.Properties().Keys.ToArray()[ob.Properties().Keys.Count - 1] + ");");

            SQLiteCommand cmd = new SQLiteCommand(query.ToString());

            foreach(var prop in ob.Properties())
                cmd.Parameters.Add(new SQLiteParameter("@" + prop.Key, prop.Value));

            db.ExecuteNonQuery(cmd);            
        }

        public void Update(IEntity ob)
        {
            //Database db = Database.GetInstance();
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

        public void Remove(IEntity ob)
        {
            //Database db = Database.GetInstance();
            StringBuilder query = new StringBuilder();
            query.Append("DELETE FROM " + ob.GetType().Name.ToUpper() + " WHERE " + ob.Properties().Keys.ToArray()[0].ToString() + "= @" +  ob.Properties().Keys.ToArray()[0].ToLower());
            SQLiteCommand cmd = new SQLiteCommand(query.ToString());
            foreach (var prop in ob.Properties())
                cmd.Parameters.Add(new SQLiteParameter("@" + prop.Key, prop.Value));
            db.ExecuteNonQuery(cmd);            
        }

    }
}
