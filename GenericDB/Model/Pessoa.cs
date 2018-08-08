using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    class Pessoa : IEntity
    {
        private string id;
        private string cpf;
        private string nome;

        public Pessoa()
        {

        }

        public Pessoa(string id, string cpf, string nome)
        {
            this.Id = id;
            this.cpf = cpf;
            this.nome = nome;
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Id
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

        public Dictionary<string, string> Properties()
        {
            Dictionary<String, String> properties = new Dictionary<string, string>();
            properties.Add("id", Id);
            properties.Add("cpf", Cpf);
            properties.Add("nome", Nome);

            return properties;
        }
    }
}
