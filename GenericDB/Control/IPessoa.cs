using GenericDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Control
{
    interface IPessoa
    {
        void Insert(Pessoa p);
        void Update(Pessoa p);
        void Delete(Pessoa p);
        Pessoa Read(int id);
        List<Pessoa> ListAll();
    }
}
