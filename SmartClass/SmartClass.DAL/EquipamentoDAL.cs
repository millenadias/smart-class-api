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

        public int retornarMinutosUsoEqpto(int pCdEquipamento, int pCdAula, String pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sql = " SELECT DATEDIFF(MI, GETDATE(), A.dt_aula) minutos " +
                                         " FROM PREFERENCIA_AULA PA INNER JOIN AULA A ON A.cd_aula = PA.cd_aula " +
                                         " WHERE cd_equipamento = " + pCdEquipamento + " AND A.cd_sala = " + pCdAula;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();

                if (retorno == null)
                    return 0;
                else
                     return int.Parse(retorno.ToString());
                
            }
        }

    }
}
