using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericDB.Util;

namespace GenericDB.DAO
{
    class ForragemInvernoDAO : GenericDBDAO
    {
        private Database db;

        public ForragemInvernoDAO()
        {
            db = Database.GetInstance();
        }


    }
}
