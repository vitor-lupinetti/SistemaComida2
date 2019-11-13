using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
      
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public double ValorGasto { get; set; }
        /*public IFormFile Imagem { get; set; }
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
                return null;*/
        
    }
}
