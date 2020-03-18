using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClass.Model
{
    public class Aula
    {
        public int CdAula { get; set; }
        public String DsHorario { get; set; }
        public int CdProfessor { get; set; }
        public Disciplina Disciplina { get; set; }
        public int QtdMaxAlunos { get; set; }
        public String DsSemestre { get; set; }
        public Sala Sala { get; set; }
        public List<Equipamento> Preferencias { get; set; }
    }
}
