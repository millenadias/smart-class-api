using SmartClass.Model;
using System;
using System.Collections.Generic;
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

        public List<Equipamento> ListarEquipamentos()
        {
            String sql = " SELECT * FROM EQUIPAMENTO";

            return new List<Equipamento>();
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
