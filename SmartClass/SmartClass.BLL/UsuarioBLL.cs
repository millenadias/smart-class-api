using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClass.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL dal = new UsuarioDAL();
        public bool ValidarAcesso(String pDsLogin, String pDsSenha)
        {
            return dal.ValidarAcesso(pDsLogin, pDsSenha);
        }

        public void Cadastrar(Usuario user)
        {
            dal.Cadastrar(user);
        }

        public Usuario Get(int pCdUsuario)
        {
            return dal.Get(pCdUsuario);
        }

        public List<Usuario> GetAlunosTurma(int pCdTurma)
        {
            return dal.GetAlunosTurma(pCdTurma);
        }
    }
}
