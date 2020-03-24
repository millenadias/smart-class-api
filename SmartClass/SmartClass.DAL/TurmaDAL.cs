using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class TurmaDAL
    {
        public void Inserir(Turma turma)
        { 
            String sql = "INSERT INTO TURMA(ds_turma, ds_turno) " +
                         "VALUES('" + turma.DsTurma + "', '" + turma.DsTurno + "')";
        }

        public void InserirAlunoTurma(int pCdAluno, int pCdTurma)
        { 
            String sql = " INSERT INTO USUARIO_TURMA(cd_usuario, cd_turma) " +
                         " VALUES(" + pCdTurma + ", " + pCdTurma + ")";
        }

        public void ExcluirTurma(int pCdTurma)
        {
            String sqlAlunoTurma = " DELETE FROM USUARIO_TURMA WHERE cd_turma = " + pCdTurma;
            String sql = " DELETE FROM TURMA WHERE cd_turma = " + pCdTurma;
        }

        public void AlterarTurma(Turma turma)
        {
            String sql = " UPDATE TURMA SET ds_turma = '" + turma.DsTurma + "', ds_turno = '" + turma.DsTurno + "'";
        }

        public List<Turma> ListarTurmas()
        {
            String sql = " SELECT * FROM TURMA";
            return new List<Turma>();
        }

        public List<Usuario> ListarAlunosTurma(int pCdTurma)
        {
            String sql = " SELECT * FROM USUARIO u " +
                         " INNER JOIN USUARIO_TURMA ut ON ut.cd_usuario = u.cd_usuario " +
                         " WHERE ut.cd_turma = " + pCdTurma;
            /* using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
             {
                 conn.Open();
                 string sql = "select cd_usuario from usuario"; // QUERY <<
                 System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                 var retorno = sqlComando.ExecuteScalar();
                 conn.Close();
             }*/
            return new List<Usuario>();
        }



    }
}
