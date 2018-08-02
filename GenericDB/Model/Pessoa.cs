using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    class Pessoa<T> where T : Pessoa<T>
    {
        private string cpf;
        private string nome;

        public Pessoa()
        {

        }
        public Pessoa(string cpf, string nome)
        {
            this.Cpf = cpf;
            this.Nome = nome;
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
    }
}
