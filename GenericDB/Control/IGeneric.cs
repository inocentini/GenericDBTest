using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Control
{
    interface IGeneric
    {
        void Insert<T>(T ob);
        void Update<T>(T ob);
        T Read<T>(T ob);
        List<T> ListAll<T>();
        void Remove<T>(T ob);
    }
}
