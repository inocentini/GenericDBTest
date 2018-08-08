using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Control
{
    interface IEntity
    {
        Dictionary<String, String> Properties();
    }
}
