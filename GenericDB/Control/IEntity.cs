using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Control
{
    /// <summary>
    /// Interface responsável por fazer a classe que implementa-la ter um método que retorna um dictionary de nome de atributo e seu valor
    /// </summary>
    interface IEntity
    {
        Dictionary<String, String> Properties();
    }
}
