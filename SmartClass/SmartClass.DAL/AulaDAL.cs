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
                    info.QtdMaxAlunos = int.Parse(dr["qtd_max_alunos"].ToString());
                    info.DsSemestre = dr["ds_semestre"].ToString();

                    listarAulas.Add(info);
                }
                conn.Close();
            }
            return listarAulas;

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
                    aula.CdProfessor = int.Parse(dr["cd_professor"].ToString());
                    aula.QtdMaxAlunos = (dr["qtd_max_alunos"] != DBNull.Value ? int.Parse(dr["qtd_max_alunos"].ToString()) : 0);
                    aula.DtAulaIni = DateTime.Parse(dr["dt_aula_ini"].ToString());
                    aula.DtAulaFim = DateTime.Parse(dr["dt_aula_fim"].ToString());
                    aula.CdDisciplina = int.Parse(dr["cd_disciplina"].ToString());
                    aula.CdTurma = int.Parse(dr["cd_turma"].ToString());
                    aula.CdSala = int.Parse(dr["cd_sala"].ToString());
                    aula.DsSemestre = dr["ds_semestre"].ToString().Trim();
                }
                conn.Close();
            }
            return aula;
        }

        public void alterarAula(Aula aula, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = "UPDATE AULA SET ds_horario = '" + aula.DsHorario + "', cd_professor = " + aula.CdProfessor +
                    ", cd_disciplina = " + aula.CdDisciplina + ", qtd_max_alunos = " + aula.QtdMaxAlunos + ", ds_semestre = '" +
                    aula.DsSemestre + "',cd_sala = " + aula.CdSala + ", cd_turma= " + aula.CdTurma + " WHERE cd_aula = " + aula.CdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }
        public int cadastrarAula(Aula aula, string pConnectionString)
        {
            int codigoAula = 0;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO AULA(ds_horario, cd_professor, cd_disciplina, qtd_max_alunos, ds_semestre, cd_sala, dt_aula_ini, dt_aula_fim, cd_turma) " +
                             " VALUES('" + aula.DsHorario + "', " + aula.CdProfessor + ", " + aula.CdDisciplina +
                             ", " + aula.QtdMaxAlunos + ", '" + aula.DsSemestre + "', " + aula.CdSala + ", " +
                             "(convert(datetime, '" + aula.DtAulaIni + "', 103)), (convert(datetime, '" + aula.DtAulaFim + "', 103)), " + aula.CdTurma + ")";
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();

                System.Data.SqlClient.SqlCommand sqlComandoSelect = new System.Data.SqlClient.SqlCommand("SELECT TOP 1 cd_aula FROM AULA ORDER BY cd_aula desc", conn);
                var codAula = sqlComandoSelect.ExecuteScalar();

                if (codAula != null)
                    codigoAula = int.Parse(codAula.ToString());
                conn.Close();
            }

            return codigoAula;
        }

        public void excluirAula(int CdAula, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " DELETE FROM AULA WHERE cd_aula = " + CdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void cadastrarPreferenciasAula(int CdAula, List<int> equipamentos, string pConnectionString)
        {

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                foreach (var equip in equipamentos)
                {
                    String sql = " INSERT INTO PREFERENCIA_AULA (cd_aula, cd_equipamento) " +
                                 " VALUES(" + CdAula + "," + equip + ")"; System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                    sqlComando.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void excluirPreferenciaAula(int CdPreferenciaAula, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " DELETE FROM PREFERENCIA_AULA WHERE cd_aula = " + CdPreferenciaAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Aula> ListarAulasProfessor(int pCdProfessor, String pConnectionString)
        {
            List<Aula> listarAulas = new List<Aula>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT AULA.*, U.ds_nome, SALA.ds_sala, D.ds_disciplina FROM AULA " +
                             " INNER JOIN SALA ON SALA.cd_sala = AULA.cd_sala " +
                             " INNER JOIN USUARIO U ON U.cd_usuario =  AULA.cd_professor " +
                             " INNER JOIN DISCIPLINA D ON D.cd_disciplina = AULA.cd_disciplina " +
                             " WHERE dt_aula_ini >= getdate() AND cd_professor = " + pCdProfessor +
                             " order by dt_aula_ini";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Aula info = new Aula();
                    info.CdAula = int.Parse(dr["cd_aula"].ToString());
                    info.DsSala = dr["ds_sala"].ToString();
                    info.DsProfessor = dr["ds_nome"].ToString();
                    info.DsHorario = dr["ds_horario"].ToString();
                    info.CdProfessor = int.Parse(dr["cd_professor"].ToString());
                    info.QtdMaxAlunos = int.Parse(dr["qtd_max_alunos"].ToString());
                    info.DsSemestre = dr["ds_semestre"].ToString();
                    info.DsDisciplina = dr["ds_disciplina"].ToString();
                    info.DtAulaIni = (dr["dt_aula_ini"] != DBNull.Value ? DateTime.Parse(dr["dt_aula_ini"].ToString()) : DateTime.MinValue);
                    listarAulas.Add(info);
                }
                conn.Close();
            }
            return listarAulas;

        }

        public List<Aula> ListarAulasDiaProfessor(int pCdProfessor, String pConnectionString)
        {
            List<Aula> listarAulas = new List<Aula>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT AULA.*, U.ds_nome, SALA.ds_sala, D.ds_disciplina FROM AULA " +
                             " INNER JOIN SALA ON SALA.cd_sala = AULA.cd_sala " +
                             " INNER JOIN USUARIO U ON U.cd_usuario =  AULA.cd_professor " +
                             " INNER JOIN DISCIPLINA D ON D.cd_disciplina = AULA.cd_disciplina " +
                             " WHERE YEAR(dt_aula_ini) = YEAR(GETDATE()) and MONTH(dt_aula_ini) = MONTH(GETDATE()) and DAY(dt_aula_ini) = DAY(GETDATE()) AND cd_professor = " + pCdProfessor +
                             " order by dt_aula_ini";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Aula info = new Aula();
                    info.CdAula = int.Parse(dr["cd_aula"].ToString());
                    info.DsSala = dr["ds_sala"].ToString();
                    info.DsProfessor = dr["ds_nome"].ToString();
                    info.DsHorario = dr["ds_horario"].ToString();
                    info.CdProfessor = int.Parse(dr["cd_professor"].ToString());
                    info.QtdMaxAlunos = int.Parse(dr["qtd_max_alunos"].ToString());
                    info.DsSemestre = dr["ds_semestre"].ToString();
                    info.DsDisciplina = dr["ds_disciplina"].ToString();
                    info.DtAulaIni = (dr["dt_aula_ini"] != DBNull.Value ? DateTime.Parse(dr["dt_aula_ini"].ToString()) : DateTime.MinValue);
                    listarAulas.Add(info);
                }
                conn.Close();
            }
            return listarAulas;

        }

        public bool ValidarAulaPermitida(int pCdSala, DateTime pDtIni, DateTime pDtFim, String pConnectionString)
        {
            bool AulaPermitida = false;

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sql = " SELECT COUNT(cd_aula) FROM AULA " +
                             " WHERE (dt_aula_ini BETWEEN (convert(datetime, '" + pDtIni + "', 103)) AND (convert(datetime, '" + pDtFim + "', 103))" +
                             " OR dt_aula_fim BETWEEN (convert(datetime, '" + pDtIni + "', 103)) and (convert(datetime, '" + pDtFim + "', 103)))" +
                             " AND cd_sala = " + pCdSala;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var countAula = sqlComando.ExecuteScalar();

                if (countAula != null && int.Parse(countAula.ToString()) > 0)
                    AulaPermitida = false;
                else
                    AulaPermitida = true;

                conn.Close();
            }

            return AulaPermitida;
        }

        public List<int> ListarPreferencias(int pCdAula, String pConnectionString)
        {
            List<int> preferencias = new List<int>();

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sql = " SELECT cd_equipamento FROM PREFERENCIA_AULA WHERE cd_aula = " + pCdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    preferencias.Add(int.Parse(dr["cd_equipamento"].ToString()));
                }
                conn.Close();
            }
            return preferencias;
        }

    }
}
