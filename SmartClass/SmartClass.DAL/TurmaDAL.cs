using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class TurmaDAL
    {
        public void Inserir(Turma turma, String pConnectionString)
        { 
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO TURMA(ds_turma, ds_turno) " +
                             " VALUES('" + turma.DsTurma + "', '" + turma.DsTurno + "')";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void InserirAlunoTurma(int pCdAluno, int pCdTurma, String pConnectionString)
        { 

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO USUARIO_TURMA(cd_usuario, cd_turma) " +
                             " VALUES(" + pCdAluno + ", " + pCdTurma + ")";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExcluirTurma(int pCdTurma, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sqlAlunoTurma = " DELETE FROM USUARIO_TURMA WHERE cd_turma = " + pCdTurma;
                System.Data.SqlClient.SqlCommand sqlComandoUsuarioTurma = new System.Data.SqlClient.SqlCommand(sqlAlunoTurma, conn);
                sqlComandoUsuarioTurma.ExecuteNonQuery();

                String sql = " DELETE FROM TURMA WHERE cd_turma = " + pCdTurma;
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }

        }

        public void AlterarTurma(Turma turma, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " UPDATE TURMA SET ds_turma = '" + turma.DsTurma + "', ds_turno = '" + turma.DsTurno + "'" +
                             " WHERE cd_turma = " + turma.CdTurma;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Turma> ListarTurmas(String pConnectionString)
        {
            List<Turma> lstTurmas = new List<Turma>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM TURMA";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Turma info = new Turma();
                    info.CdTurma = int.Parse(dr["cd_turma"].ToString());
                    info.DsTurma = dr["ds_turma"].ToString();
                    info.DsTurno = dr["ds_turno"].ToString();
                    lstTurmas.Add(info);
                }
                conn.Close();
            }
            return lstTurmas;
        }
    }
}
