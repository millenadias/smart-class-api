using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SmartClass.DAL
{
    public class UsuarioDAL
    {
        public bool ValidarAcesso(String pDsLogin, String pDsSenha, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                
                String sql = string.Format("SELECT cd_usuario FROM USUARIO WHERE ds_login = '{0}' AND ds_senha = '{1}'", pDsLogin, pDsSenha);
                //String sql = "SELECT cd_usuario FROM USUARIO WHERE ds_login = '" + pDsLogin + "'"; // AND ds_senha = '" + pDsSenha + "'";
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();

                if (retorno != null)
                    return true;
                else
                    return false;
            }
        }

        public void Cadastrar(Usuario user, String pConnectionString)
        {

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO USUARIO(ds_nome, ds_login, ds_senha, cd_tipo_usuario) " +
                             " VALUES('" + user.dsNome + "', '" + user.dsLogin + "', '" + user.dsSenha + "', " + user.cdTipoUsuario + ")";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Usuario Get(int pCdUsuario, String pConnectionString)
        {
            Usuario user = new Usuario();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM USUARIO WHERE cd_usuario = " + pCdUsuario.ToString();

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                if (dr.Read())
                {
                    user.cdUsuario = int.Parse(dr["cd_usuario"].ToString());
                    user.dsNome = dr["ds_nome"].ToString().Trim();
                    user.dsLogin = dr["ds_login"].ToString().Trim();
                    user.cdTipoUsuario = int.Parse(dr["cd_tipo_usuario"].ToString());
                }
                conn.Close();
            }


            return user;
        }

        public Usuario GetPorLoginSenha(String pDsLogin, String pDsSenha, String pConnectionString) 
        {
            Usuario user = new Usuario();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM USUARIO WHERE ds_login = '" + pDsLogin.ToString() + "' AND ds_senha = '" + pDsSenha + "'";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                if (dr.Read())
                {
                    user.cdUsuario = int.Parse(dr["cd_usuario"].ToString());
                    user.dsNome = dr["ds_nome"].ToString().Trim();
                    user.dsLogin = dr["ds_login"].ToString().Trim();
                    user.cdTipoUsuario = int.Parse(dr["cd_tipo_usuario"].ToString());
                }
                conn.Close();
            }


            return user;
        }

        public List<Usuario> GetAlunosTurma(int pCdTurma, String pConnectionString)
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
             using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM USUARIO u " +
                             " INNER JOIN USUARIO_TURMA ut ON ut.cd_usuario = u.cd_usuario " +
                             " WHERE ut.cd_turma = " + pCdTurma; 
                
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Usuario info = new Usuario();
                    info.cdUsuario = int.Parse(dr["cd_usuario"].ToString());
                    info.dsNome = dr["ds_nome"].ToString();
                    info.dsLogin = dr["ds_login"].ToString();
                    info.cdTipoUsuario = int.Parse(dr["cd_tipo_usuario"].ToString());
                    lstUsuarios.Add(info);
                }
                 conn.Close();
            }
            return lstUsuarios;
        }

        public void Alterar(Usuario user, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " UPDATE USUARIO SET ds_nome = '" + user.dsNome + "', ds_login = '" + user.dsLogin + "', " +
                             " ds_senha = '" + user.dsSenha + "', cd_tipo_usuario = " + user.cdTipoUsuario +
                             " WHERE cd_usuario = " + user.cdUsuario;
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
