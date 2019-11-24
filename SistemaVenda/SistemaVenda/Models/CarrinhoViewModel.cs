using System;
namespace SistemaVenda.Models
{
    public class CarrinhoViewModel : PadraoViewModel
    {
        public int Quantidade { get; set; }
        public int IdComida{ get; set; }
        public int IdCidadeEntrega { get; set; }
        public string Nome { get; set; }

        public string ImagemEmBase64 { get; set; }
        public double Preco { get; set; }
    }
}
