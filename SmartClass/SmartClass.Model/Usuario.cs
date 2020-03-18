using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClass.Model
{
    public class Usuario
    {
        public int CdUsuario { get; set; }
        public String DsNome { get; set; }
        public String DsLogin { get; set; }
        public String DsSenha { get; set; }
        public int CdTipoUsuario { get; set; }
    }
}
