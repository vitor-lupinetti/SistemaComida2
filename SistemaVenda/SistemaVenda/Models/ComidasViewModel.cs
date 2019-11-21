using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class ComidasViewModel:PadraoViewModel
    {
       
        public string Descricao { get; set; }
        public double? Preco { get; set; }
        public int IdCategoria { get; set; }
        public int IdEmbalagem { get; set; }
        public IFormFile Imagem { get; set; }
        public string ImageBase64 { get; set; }

        public byte[] ImageByte()
        {
            if (Imagem != null)
                using (var ms = new MemoryStream())
                {
                    Imagem.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }
    }
}
