using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.Model
{
    public class Turma
    {
        public int CdTurma { get; set; }
        public String DsTurma { get; set; }
        public String DsTurno { get; set; }
        public List<Usuario> Alunos { get; set; }
        public List<Aula> Aulas { get; set; }
    }
}
