using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Control
{
    /// <summary>
    /// Interface responsável por fazer a classe que implementa-la ter métodos de Insert, Update e Remove que recebem um objeto genérico do tipo "T".
    /// </summary>
    interface IGeneric
    {
        void Insert<T>(T ob);
        void Update<T>(T ob);
        void Remove<T>(T ob);
    }
}
