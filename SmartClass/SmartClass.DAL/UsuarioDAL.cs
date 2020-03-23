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
        public bool ValidarAcesso(string pConnectionString, String pDsLogin, String pDsSenha)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                string sql = "select cd_usuario from usuario"; // QUERY <<
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();
            }
            return true; //retornar true ou false conforme acesso válido
        }

        public void Cadastrar(string pConnectionString, Usuario user)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                string sql = "select cd_usuario from usuario"; // QUERY <<
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();
            }
        }

        public Usuario Get(string pConnectionString, int pCdUsuario)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                string sql = "select cd_usuario from usuario"; // QUERY <<
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();
            }
            return new Usuario();
        }

        public List<Usuario> GetAlunosTurma(string pConnectionString, int pCdTurma)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                string sql = "select cd_usuario from usuario"; // QUERY <<
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();
            }
            return new List<Usuario>();
        }
    }
}
