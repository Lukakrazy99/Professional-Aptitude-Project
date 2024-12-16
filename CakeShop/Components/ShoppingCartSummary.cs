using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ICarroComprasService _carroCompras;

        public ShoppingCartSummary(ICarroComprasService carroCompras)
        {
            _carroCompras = carroCompras;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carroComprasCountTotal = await _carroCompras.GetCarroCountAndTotalAmmountAsync();
            var carroComprasViewModel = new CarroComprasViewModel
            {
                CarroCompras = _carroCompras,
                CarroComprasItemsTotal = carroComprasCountTotal.ItemCount,
                CarroComprasTotal = carroComprasCountTotal.TotalAmmount
            };
            return View(carroComprasViewModel);
        }

      
    }
}
