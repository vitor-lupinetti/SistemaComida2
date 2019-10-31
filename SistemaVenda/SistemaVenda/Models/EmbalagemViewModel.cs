using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class EmbalagemViewModel:PadraoViewModel
    {
       
        public string Descricao { get; set; }
        public int QtdEstoque { get; set; }
    }
}
