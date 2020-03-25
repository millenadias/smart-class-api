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

        public void cadastrarAula(int CdAula, int CdDisciplina, String pConnectionString)
        {
            dal.cadastrarAula(CdAula, CdDisciplina, pConnectionString);
        }


        public void excluirAula(int CdAula, String pConnectionString)
        {
            dal.excluirAula(CdAula, pConnectionString);
        }
    }
}
