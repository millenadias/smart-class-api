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

        public List<Equipamento> ListarEquipamentos(int codSala)
        {
            return dal.ListarEquipamentos(codSala);

        }

        public bool verificarDisponibilidade(int codSala, string horario)
        {
            return dal.verificarDisponibilidade(codSala, horario);
        }

        public Sala getSala(int cdSala)
        {
            return dal.getSala(cdSala);

        }

        public void cadastrarEquipamento(int codEquipamento, int codSala)
        {
            dal.cadastrarEquipamento(codEquipamento, codSala);
        }

        public void excluirEquipamento(int codEquipamentoSala)
        {
            dal.excluirEquipamento(codEquipamentoSala);
        }
    }
}
