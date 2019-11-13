using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class PromocaoViewModel: PadraoViewModel
    {
        
        public int IdCategoria { get; set; }
        public double Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
