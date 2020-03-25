using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class SalaBLL
    {
        SalaDAL dal = new SalaDAL();
        public List<Sala> ListarSalas(String pConnectionString)
        {
            return dal.ListarSalas(pConnectionString);
        }

        public List<Equipamento> ListarEquipamentos(int codSala, String pConnectionString)
        {
            return dal.ListarEquipamentos(codSala, pConnectionString);

        }

        public bool verificarDisponibilidade(int codSala, string horario, string pConnectionString)
        {
            return dal.verificarDisponibilidade(codSala, horario, pConnectionString);
        }
 
        public Sala getSala(int cdSala, string pConnectionString)
        {
            return dal.getSala(cdSala, pConnectionString);

        }

        public void cadastrarEquipamento(int codEquipamento, int codSala, string pConnectionString)
        {
            dal.cadastrarEquipamento(codEquipamento, codSala, pConnectionString);
        }

        public void excluirEquipamento(int codEquipamentoSala, string pConnectionString)
        {
            dal.excluirEquipamento(codEquipamentoSala, pConnectionString);
        }
    }
}
