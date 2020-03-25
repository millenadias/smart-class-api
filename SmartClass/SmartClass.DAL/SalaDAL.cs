using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.DAL
{
    public class SalaDAL
    {

        public List<Sala> ListarSalas(String pConnectionString)
        {
            List<Sala> lstSalas = new List<Sala>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM SALA";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Sala info = new Sala();
                    info.CdSala = int.Parse(dr["cd_sala"].ToString());
                    info.DsSala = dr["ds_sala"].ToString();
                    info.DsBloco = dr["ds_bloco"].ToString();
                    lstSalas.Add(info);
                }
                conn.Close();
            }
            return lstSalas;
        }

        public List<Equipamento> ListarEquipamentos(int codSala, String pConnectionString)
        {
            List<Equipamento> lstEqptos = new List<Equipamento>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " SELECT * FROM EQUIPAMENTO_SALA es " + 
                             " INNER JOIN EQUIPAMENTO e ON e.cd_equipamento = es.cd_equipamento " + 
                             " WHERE cd_sala = " + codSala;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                DbDataReader dr = sqlComando.ExecuteReader();

                while (dr.Read())
                {
                    Equipamento info = new Equipamento();
                    info.CdEquipamento = int.Parse(dr["cd_equipamento"].ToString());
                    info.DsEquipamento = dr["ds_equipamento"].ToString();
                    lstEqptos.Add(info);
                }
                conn.Close();
            }

            return lstEqptos;
        }

        public bool verificarDisponibilidade (int codSala, string horario, string pConnectionString)
        {

            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();

                String sql = "SELECT cd_aula FROM AULA WHERE cd_sala = " + codSala + " AND ds_horario = '" + horario + "'";
                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                var retorno = sqlComando.ExecuteScalar();
                conn.Close();

                if (retorno == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Sala getSala(int cdSala, string pConnectionString)
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
        }

        public void cadastrarEquipamento (int codEquipamento, int codSala, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " INSERT INTO EQUIPAMENTO_SALA(cd_sala, cd_equipamento) " +
                             " VALUES(" + codSala + ", " + codEquipamento + ")";

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void excluirEquipamento (int codEquipamentoSala, string pConnectionString)
        {
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(pConnectionString))
            {
                conn.Open();
                String sql = " DELETE FROM EQUIPAMENTO_SALA WHERE cd_equipamento_sala = " + codEquipamentoSala;

                System.Data.SqlClient.SqlCommand sqlComando = new System.Data.SqlClient.SqlCommand(sql, conn);
                sqlComando.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
