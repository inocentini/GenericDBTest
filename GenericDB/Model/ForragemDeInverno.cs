using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    class ForragemDeInverno : IEntity
    {
        private int id;
        private String desc;
        private int qnt;
        private double preco;

        public ForragemDeInverno()
        {

        }

        public ForragemDeInverno(int id, string desc, int qnt, double preco)
        {
            this.Id = id;
            this.Desc = desc;
            this.Qnt = qnt;
            this.Preco = preco;
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
            Dictionary<String, String> atts = new Dictionary<string, string>();
            foreach (var a in this.GetType().GetProperties().ToArray())
                atts.Add(a.GetType().Name, a.Attributes.ToString());
            return atts;

        }
    }
}
