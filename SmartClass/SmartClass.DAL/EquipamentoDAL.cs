using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class EquipamentoDAL
    {
        public void Inserir(String pDsEquipamento)
        {
            String sql = " INSERT INTO EQUIPAMENTO (ds_equipamento) VALUES ('" + pDsEquipamento + "')";
        }

        public void Alterar(Equipamento eqpto)
        {
            String sql = " UPDATE EQUIPAMENTO SET ds_equipamento = '" + eqpto.DsEquipamento + "' WHERE cd_equipamento = " + eqpto.CdEquipamento;
        }

        public void Excluir(int pCdEquipamento)
        {
            String sql = " DELETE FROM EQUIPAMENTO WHERE cd_equipamento = " + pCdEquipamento;
        }

        public List<Equipamento> ListarEquipamentos(int pCdSala, String pConnectionString)
        {
            List<Equipamento> lstEquipamentos = new List<Equipamento>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM EQUIPAMENTO WHERE cd_sala = " + pCdSala;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Equipamento info = new Equipamento();
                    info.CdEquipamento = int.Parse(dr["cd_equipamento"].ToString());
                    info.DsEquipamento = dr["ds_equipamento"].ToString();
                    lstEquipamentos.Add(info);
                }
                conn.Close();
            }
            return lstEquipamentos;
        }


        public List<Disciplina> ListarDisciplinas(String pConnectionString)
        {
            List<Disciplina> lstDisciplinas = new List<Disciplina>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM DISCIPLINA";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Disciplina info = new Disciplina();
                    info.CdDisciplina = int.Parse(dr["cd_disciplina"].ToString());
                    info.DsDisciplina = dr["ds_disciplina"].ToString();
                    lstDisciplinas.Add(info);
                }
                conn.Close();
            }
            return lstDisciplinas;

        }

        public bool ligarEquipamento(int pCdEquipamento, int pCdSala, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sql = " SELECT DATEDIFF(MI, GETDATE(), A.dt_aula_ini) minutos, dt_aula_ini, dt_aula_fim " +
                             " FROM PREFERENCIA_AULA PA INNER JOIN AULA A ON A.cd_aula = PA.cd_aula " +
                             " WHERE cd_equipamento = " + pCdEquipamento + " AND A.cd_sala = " + pCdSala +
                             " AND (GETDATE() < dt_aula_fim OR dt_aula_fim = GETDATE())";

         
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                int minutosParaUso = 0;
                DateTime dataIni = new DateTime();
                DateTime dataFim = new DateTime();
                if (dr.Read())
                {
                    minutosParaUso = int.Parse(dr["minutos"].ToString());
                    dataIni = DateTime.Parse(dr["dt_aula_ini"].ToString());
                    dataFim = DateTime.Parse(dr["dt_aula_fim"].ToString());
                }

                if (minutosParaUso <= 5 && minutosParaUso > 0)
                    return true;
                else if (DateTime.Now <= dataFim && DateTime.Now >= dataIni)
                    return true;
                else
                    return false;

            }
        }

        /* public Sala getSala(int cdSala, string pConnectionString)
        {
            Sala sala = new Sala();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM SALA WHERE cd_sala = " + cdSala;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                if (dr.Read())
                {
                    sala.CdSala = int.Parse(dr["cd_sala"].ToString());
                    sala.DsSala = dr["ds_sala"].ToString().Trim();
                    sala.DsBloco = dr["ds_bloco"].ToString().Trim();
                }
                conn.Close();
            }
            return sala;
        }*/

    }
}
