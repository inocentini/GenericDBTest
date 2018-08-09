using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    class ForragemDeVerao : IEntity
    {
        private int id;
        private String desc;
        private int qnt;
        private double preco;

        public ForragemDeVerao()
        {

        }
        public ForragemDeVerao(int id, string desc, int qnt, double preco)
        {
            this.id = id;
            this.desc = desc;
            this.qnt = qnt;
            this.preco = preco;
        }

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
