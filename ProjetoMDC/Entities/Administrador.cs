using System;
using System.Data.SqlTypes;
namespace MorangosDaCidade.Entities
{
  
    class Administrador : Usuario
    {
        public Administrador(string nome, string cpf, string email, string telefone, 
            SqlDateTime dataNascimento, string senha) : 
            base(nome, cpf, email, telefone, dataNascimento, senha)
        {
        }

        public Administrador()
        {

        }
    }
}