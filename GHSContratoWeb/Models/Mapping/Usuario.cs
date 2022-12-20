using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHSContratoWeb.Models.Mapping
{
    public class Usuario
    {
        public string ID { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
