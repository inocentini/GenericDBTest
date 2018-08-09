using GenericDB.Control;
using GenericDB.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericDB.DAO
{
    class GenericDBDAO : IGeneric
    {
        private Database db;

        public GenericDBDAO()
        {
            db = Database.GetInstance();
        }

        public void Insert<T>(T ob)
        {
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO " + ob.GetType().Name.ToUpper() + "(");
            for(int i =0; i< ob.GetType().GetProperties().ToArray().Count() - 1; i++)
            {
                query.Append(ob.GetType().GetProperties()[i].Name.ToLower() +", ");
            }
            query.Append(ob.GetType().GetProperties()[ob.GetType().GetProperties().ToArray().Count() - 1].Name.ToLower() + ") VALUES(");

            for(int i=0; i< ob.GetType().GetProperties().ToArray().Count() - 1; i++)
            {
                query.Append("@" + ob.GetType().GetProperties()[i].Name.ToLower() + ", ");
            }
            query.Append(ob.GetType().GetProperties()[ob.GetType().GetProperties().ToArray().Count() - 1].Name.ToLower() + ");");

            SQLiteCommand cmd = new SQLiteCommand(query.ToString());

            Type type = ob.GetType();
            PropertyInfo[] attrs = ob.GetType().GetProperties();

            foreach(var atts in attrs)
            {
                //cmd.Parameters.Add(new SQLiteParameter("@" + atts.Name, atts.GetValue(ob)));
                Console.WriteLine(atts.Name.ToLower());
                
                Console.WriteLine(atts.GetValue(ob));
            }

            
            db.ExecuteNonQuery(cmd);

        }

        public List<T> ListAll<T>()
        {
            throw new NotImplementedException();
        }

        public T Read<T>(T ob)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T ob)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T ob)
        {
            throw new NotImplementedException();
        }
    }
}
