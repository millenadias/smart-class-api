using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();
        public String connectionString = "";
        public bool ValidarAcesso(String pDsLogin, String pDsSenha, String pConnectionString)
        {
            return dal.ValidarAcesso(pDsLogin, pDsSenha, pConnectionString);
        }

        public void Cadastrar(Usuario user, String pConnectionString)
        {
            dal.Cadastrar(user, pConnectionString);
        }

        public void Alterar(Usuario user, String pConnectionString)
        {
            dal.Alterar(user, pConnectionString);
        }
        public Usuario Get(int pCdUsuario, String pConnectionString)
        {
            return dal.Get(pCdUsuario, pConnectionString);
        }

        public List<Usuario> GetAlunosTurma(int pCdTurma, String pConnectionString)
        {
            return dal.GetAlunosTurma(pCdTurma, pConnectionString);
        }
    }
}
