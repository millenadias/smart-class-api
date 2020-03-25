using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.Model
{
    public class Aula
    {
        public int CdAula { get; set; }
        public int CdDisciplina { get; set; }
        public int CdSala { get; set; }


        public String DsHorario { get; set; }
        public int CdProfessor { get; set; }
        public Disciplina Disciplina { get; set; }
        public int QtdMaxAlunos { get; set; }
        public String DsSemestre { get; set; }

        public object listarAulas()
        {
            throw new NotImplementedException();
        }

        public Sala Sala { get; set; }

        public List<Equipamento> Preferencias { get; set; }

    }
}
