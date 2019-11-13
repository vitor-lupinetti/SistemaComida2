using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class EntregadorViewModel : PadraoViewModel
    {
        
        public string Nome { get; set; }
        public int IdCidadeEntrega { get; set; }
    }
}
