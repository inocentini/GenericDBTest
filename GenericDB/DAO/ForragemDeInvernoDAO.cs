using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDB.Util;

namespace GenericDB.DAO
{
    class ForragemDeInvernoDAO : GenericTDAO
    {
        private Database db;

        public ForragemDeInvernoDAO()
        {
            db = Database.GetInstance();
        }


    }
}
