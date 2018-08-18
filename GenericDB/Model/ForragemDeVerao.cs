using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    /// <summary>
    /// Classe Modelo de Forragem de Verão
    /// </summary>
    class ForragemDeVerao : IEntity
    {
        /// <summary>
        /// Atributos da classe ForragemDeVerao
        /// </summary>
        private int id;
        private String desc;
        private int qnt;
        private double preco;

        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ForragemDeVerao()
        {

        }

        /// <summary>
        /// Construtor completo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="desc"></param>
        /// <param name="qnt"></param>
        /// <param name="preco"></param>
        public ForragemDeVerao(int id, string desc, int qnt, double preco)
        {
            this.id = id;
            this.desc = desc;
            this.qnt = qnt;
            this.preco = preco;
        }

        /// Métodos Getter e Setter da classe ForragemDeVerão
        
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public int Qnt
        {
            get
            {
                return qnt;
            }

            set
            {
                qnt = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }
       
        /// <summary>
        /// Método implementado da interface IEntity, retorna um dictionary de chave valor de nome do atributo e seu valor
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> Properties()
        {
            Dictionary<String, String> properties = new Dictionary<string, string>();
            properties.Add("id", Id.ToString());
            properties.Add("desc", Desc);
            properties.Add("qnt", Qnt.ToString());
            properties.Add("preco", Preco.ToString());

            return properties;
        }
    }
}
