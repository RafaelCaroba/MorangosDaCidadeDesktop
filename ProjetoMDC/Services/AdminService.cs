using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MorangosDaCidade.Entities;
using MorangosDaCidade.Repository;
namespace MorangosDaCidade.Service
{
    class AdminService
    {
        public AdministradorRepository adminRepository = new AdministradorRepository();

        public bool SalvarAdmin(Administrador a)
        {

            if (adminRepository.CadastrarAdministrador(a) > 0)
            {
                return true;
            }
            return false;
        }

        
        public async Task<Administrador> BuscarAdministradorPorEmailSenhaAsync(string email, string senha)
        {
            Administrador administrador = await adminRepository.BuscarAdministradorPorEmailSenhaAsync(email, senha);

            if (administrador == null)
            {
                throw new Exception("Administrador não encontrado com o email e senha fornecidos.");
            }

            return administrador;
        }

    }
}