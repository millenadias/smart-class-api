using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClass.Model
{
    public class Sala
    {
        public int CdSala { get; set; }
        public String DsSala { get; set; }
        public String DsBloco { get; set; }
        public List<Equipamento> EquipamentosDisponiveis { get; set; }
    }
}
