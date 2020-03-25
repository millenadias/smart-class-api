using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class AulaBLL
    {
        AulaDAL dal = new AulaDAL();


        public List<Aula> ListarAulas(String pConnectionString)
        {
            return dal.ListarAulas(pConnectionString);
        }


        public Aula getAula(int CdAula, String pConnectionString)
        {
            return dal.getAula(CdAula, pConnectionString);
        }

        public void alterarAula(Aula aula, string pConnectionString)
        {
            dal.alterarAula(aula, pConnectionString);
        }

        public void cadastrarAula(Aula aula, String pConnectionString)
        {
            dal.cadastrarAula(aula, pConnectionString);
        }

        public void cadastrarPreferenciaAula(int CdAula, int CdEquipamento, String pConnectionString)
        {
            dal.cadastrarPreferenciaAula(CdAula, CdEquipamento, pConnectionString);
        }


        public void excluirAula(int CdAula, String pConnectionString)
        {
            dal.excluirAula(CdAula, pConnectionString);
        }

        public void excluirPreferenciaAula(int CdPreferenciaAula, String pConnectionString)
        {
            dal.excluirPreferenciaAula(CdPreferenciaAula, pConnectionString);
        }
    }
}
