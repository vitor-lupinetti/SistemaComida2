using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class VendaViewModel : PadraoViewModel
    {
        
        public DateTime DataVenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdEntregador { get; set; }
        public int IdCidade { get; set; }
    }
}
