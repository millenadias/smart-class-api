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
        public void Inserir(Turma turma)
        {
            dal.Inserir(turma);
        }

        public void InserirAlunoTurma(int pCdAluno, int pCdTurma)
        {
            dal.InserirAlunoTurma(pCdAluno, pCdTurma);
        }

        public void ExcluirTurma(int pCdTurma)
        {
            dal.ExcluirTurma(pCdTurma);
        }

        public void AlterarTurma(Turma turma)
        {
            dal.AlterarTurma(turma);
        }

        public List<Turma> ListarTurmas()
        {
            return dal.ListarTurmas();
        }

        public List<Usuario> ListarAlunosTurma(int pCdTurma)
        {
            return dal.ListarAlunosTurma(pCdTurma);
        }
    }
}
