using System;
using System.Collections.Generic;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;

namespace CakeShop.Core.ViewModel
{
    public class MinhasVendasViewModel
    {
        public ICarroComprasService CarroCompras { get; set; }
        public decimal CarroComprasTotal { get; set; }
        public int CarroComprasItemsTotal { get; set; }
        public VendaDetalhes vendadetalhes { get; set; }
        public decimal TotalVenda { get; set; }
       
        public DateTime Data { get; set; }
        public IEnumerable<InfoVendaJogo> InfosVendaJogo { get; set; }
        
        
        
    }

    public class InfoVendaJogo
    {
        public int Qnt { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
    }
}
