using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class AulaDAL
    {
        public List<Aula> ListarAulas(String pConnectionString)
        {
            List<Aula> listarAulas = new List<Aula>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM AULA";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Aula info = new Aula();
                    Disciplina info2 = new Disciplina();
                    info.CdAula = int.Parse(dr["cd_aula"].ToString());
                    info.DsHorario = dr["ds_horario"].ToString();
                    info.CdProfessor = int.Parse(dr["cd_professor"].ToString());
                    info2.CdDisciplina = int.Parse(dr["cd_disciplina"].ToString());
                    info2.DsDisciplina = dr["ds_disciplina"].ToString();
                    info.QtdMaxAlunos = int.Parse(dr["qtd_max_alunos"].ToString());
                    info.DsSemestre = dr["ds_semestre"].ToString();

                    listarAulas.Add(info);
                }
                conn.Close();
            }
            return listarAulas

            //verificar se deverá criar outro metodo de listarDisciplinas
        }

        public Aula getAula(int CdAula, string pConnectionString)
        {
            Aula aula = new Aula();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM AULA WHERE cd_aula = " + CdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                if (dr.Read())
                {
                    aula.CdAula = int.Parse(dr["cd_aula"].ToString());
                    aula.DsHorario = dr["ds_horario"].ToString().Trim();
                    aula.CdProfessor = int.Parse(dr["cd_orofessor"].ToString());
                    aula.QtdMaxAlunos = int.Parse(dr["qtd_max_alunos"].ToString());
                    aula.DsSemestre = dr["ds_semestre"].ToString().Trim();
                }
                conn.Close();
            }
            return aula;
        }

        public void cadastrarAula (int CdAula, int CdDisciplina, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO DISCIPLINA_AULA(cd_aula, cd_disciplina) " +
                             " VALUES(" + CdAula + ", " + CdDisciplina + ")";
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }



        public void excluirAula (int CdAula, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " DELETE FROM DISCIPLINA_AULA WHERE cd_disciplina_aula = " + CdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
