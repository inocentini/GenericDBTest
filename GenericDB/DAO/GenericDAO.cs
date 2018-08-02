using GenericDB.Control;
using GenericDB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.DAO
{
    class GenericDAO : IGeneric
    {
        public void Insert<T>(T ob)
        {
            GenericDatabase gdb = GenericDatabase.GetInstance();
            String query = String.Format("INSERT INTO '{0}' VALUES()", ob) 
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
