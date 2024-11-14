using System;
using System.Data.SqlTypes;
namespace MorangosDaCidade.Entities
{
    class Cliente : Usuario
    {
        public string Endereco { get; set; }
        public Cliente(string nome, string cpf, string email, string telefone, 
            SqlDateTime dataNascimento, string senha, string endereco) : 
            base(nome, cpf, email, telefone, dataNascimento, senha)
        {
            Endereco = endereco;
        }

        public Cliente(int id, string nome, string cpf, string email, string telefone,
            SqlDateTime dataNascimento, string senha, string endereco) :
            base(id, nome, cpf, email, telefone, dataNascimento, senha)
        {
            Endereco = endereco;
        }

        public Cliente()
        {

        }
    }
}