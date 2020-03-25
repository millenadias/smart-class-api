using SmartClass.DAL;
using SmartClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.BLL
{
    public class TurmaBLL
    {
        TurmaDAL dal = new TurmaDAL();
        public void Inserir(Turma turma, String pConnectionString)
        {
            dal.Inserir(turma, pConnectionString);
        }

        public void InserirAlunoTurma(int pCdAluno, int pCdTurma, String pConnectionString)
        {
            dal.InserirAlunoTurma(pCdAluno, pCdTurma, pConnectionString);
        }

        public void ExcluirTurma(int pCdTurma,String pConnectionString)
        {
            dal.ExcluirTurma(pCdTurma, pConnectionString);
        }

        public void AlterarTurma(Turma turma, String pConnectionString)
        {
            dal.AlterarTurma(turma, pConnectionString);
        }

        public List<Turma> ListarTurmas(String pConnectionString)
        {
            return dal.ListarTurmas(pConnectionString);
        }

       
    }
}
