
using CakeShop.Core.Models;

namespace CakeShop.Core.ViewModel
{
    public class CarroComprasViewModel
    {
        public ICarroComprasService CarroCompras { get; set; }
        public decimal CarroComprasTotal { get; set; }
        public int CarroComprasItemsTotal { get; set; }
    }
}
