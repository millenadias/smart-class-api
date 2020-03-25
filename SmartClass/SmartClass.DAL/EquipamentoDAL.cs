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
    }
}
