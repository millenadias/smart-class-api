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


        public List<Aula> ListarAulas()
        {
            return dal.ListarAulas();
        }


        public Aula getAula(int CdAula)
        {
            return dal.getAula(CdAula);
        }

        public void cadastrarAula(int CdAula)
        {
            dal.cadastrarAula(CdAula);
        }

        public void editarAula(int CdAula)
        {
            dal.editarAula(CdAula);
        }

        public void excluirAula(int CdAula)
        {
            dal.excluirAula(CdAula);
        }
    }
}
