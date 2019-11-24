using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class AjustePrecoViewModel: PadraoViewModel
    {
        
        public int IdCategoria { get; set; }
        public double Porcentagem { get; set; }
        public string Opcao { get; set; } 
      
    }
}
