using GenericDB.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDB.Model
{
    /// <summary>
    /// Classe Modelo de Pessoa
    /// </summary>
    class Pessoa : IEntity
    {
        /// <summary>
        /// Atributos da classe Pessoa
        /// </summary>
        private string id;
        private string cpf;
        private string nome;

        /// <summary>
        /// Construtor vazio da classe Pessoa
        /// </summary>
        public Pessoa()
        {

        }

        /// <summary>
        /// Construtor completo da classe Pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cpf"></param>
        /// <param name="nome"></param>
        public Pessoa(string id, string cpf, string nome)
        {
            this.Id = id;
            this.cpf = cpf;
            this.nome = nome;
        }

        /// <summary>
        /// Método Getter e Setter de CPF
        /// </summary>
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

        /// <summary>
        /// Método Getter e Setter de Nome
        /// </summary>
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

        /// <summary>
        /// Método Getter e Setter de Id
        /// </summary>
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

        /// <summary>
        /// Método implementado da interface IEntity, retorna um dictionary de chave valor de nome do atributo e seu valor
        /// </summary>
        /// <returns></returns>
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
