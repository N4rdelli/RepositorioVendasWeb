using System.ComponentModel.DataAnnotations;

namespace AppVendasWeb.Models
{
    public class NovaVenda
    {
        public Guid NovaVendaId { get; set; }

        [Display(Name = "Nota Fiscal")]
        public int? NotaFiscal { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Display(Name = "Total dos Produtos")]
        public double TotalProdutos { get; set; }

        [Display(Name = "Valor do Desconto")]
        public double TotalDesconto { get; set; }

        [Display(Name = "Percentual de Desconto")]
        public double PercentualDesconto { get; set; }

        [Display(Name = "Total Final")]
        public double TotalFinal { get; set; }
    }
}
