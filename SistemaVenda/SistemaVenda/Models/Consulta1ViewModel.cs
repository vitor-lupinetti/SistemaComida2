using System;
namespace SistemaVenda.Models
{
    public class Consulta1ViewModel : ComidasViewModel
    {
        public string Filtro1 { get; set; }
        public string Filtro2 { get; set; }
        public string Filtro3 { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cidade { get; set;}
    }
}
