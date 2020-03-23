using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class UsuarioDAL
    {
        public bool ValidarAcesso(String pDsLogin, String pDsSenha)
        {
            //String sql = "SELECT cd_usuario FROM USUARIO WHERE ds_login = '" + pDsLogin + "' AND ds_senha = '" + pDsSenha + "'";
		//teste lucas primeiro commit
            return true; //retornar true ou false conforme acesso válido
        }

        public void Cadastrar(Usuario user)
        {

        }

        public Usuario Get(int pCdUsuario)
        {
            return new Usuario();
        }

        public List<Usuario> GetAlunosTurma(int pCdTurma)
        {
            return new List<Usuario>();
        }
    }
}
