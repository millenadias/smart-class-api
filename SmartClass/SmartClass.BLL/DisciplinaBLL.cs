using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class DisciplinaBLL
    {
        DisciplinaDAL dal = new DisciplinaDAL();

        public List<Disciplina> ListarDisciplinas(String pConnectionString)
        {
            return dal.ListarDisciplinas(pConnectionString);
        }
    }
}
