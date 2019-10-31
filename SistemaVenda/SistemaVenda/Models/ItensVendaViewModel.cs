using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class ItensVendaViewModel: PadraoViewModel
    {
        
        public int IdComida { get; set; }
        public int Qtd { get; set; }
    }
}
