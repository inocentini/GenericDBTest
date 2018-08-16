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
        void Remove<T>(T ob);
    }
}
