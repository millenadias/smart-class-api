using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClass.Model
{
    public class Usuario
    {
        public int cdUsuario { get; set; }
        public String dsNome { get; set; }
        public String dsLogin { get; set; }
        public String dsSenha { get; set; }
        public int cdTipoUsuario { get; set; }
    }
}
