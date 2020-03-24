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

        public List<Equipamento> ListarEquipamentos(int codSala)
        {
            
            return new List<Equipamento>();

        }

        public bool verificarDisponibilidade (int codSala, string horario)
        {
            return true;
        }

        public Sala getSala(int cdSala)
        {
            return new Sala();
        }

        public void cadastrarEquipamento (int codEquipamento, int codSala)
        {

        }

        public void excluirEquipamento (int codEquipamentoSala)
        {

        }
    }
}
