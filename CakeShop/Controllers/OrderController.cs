using AutoMapper;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICarroComprasService _carroComprasService;
        private readonly IMapper _mapper;
        private readonly IGuardarVendas _IGuardarVendas;

        public OrderController(
            ICarroComprasService carroComprasService,
            IMapper mapper,
            IGuardarVendas IGuardarVendas)
        {
            _carroComprasService = carroComprasService;
            _mapper = mapper;
            _IGuardarVendas = IGuardarVendas;
        }

        public async Task<IActionResult> Checkout()
        {
          
            await _carroComprasService.GetCarroComprasItemsAsync();
            var carroComprasCountTotal = await _carroComprasService.GetCarroCountAndTotalAmmountAsync();
            var minhasVendasViewModel = new MinhasVendasViewModel
            {
                CarroCompras = _carroComprasService,
                CarroComprasItemsTotal = carroComprasCountTotal.ItemCount,
                TotalVenda = carroComprasCountTotal.TotalAmmount,
            };
            var carroItems = await _carroComprasService.GetCarroComprasItemsAsync();
            if (carroItems?.Count() <= 0)
            {
                return Redirect("/carroCompras");
            }
            return View(minhasVendasViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromForm] VendaDetalhes vendaDetalhes)
        {
            if (!ModelState.IsValid)
            {
                return View(vendaDetalhes);
            }

            var carroItems = await _carroComprasService.GetCarroComprasItemsAsync();

            if (carroItems?.Count() <= 0)
            {
                ModelState.AddModelError("", "O teu carrinho encontra-se vazio. Por favor adicione alguns jogos, antes de avançar com a sua compra");
                return View(vendaDetalhes);
            }

            var venda = _mapper.Map<VendaDetalhes, Order>(vendaDetalhes);
            venda.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _IGuardarVendas.CreateVendasAsync(venda);

            await _carroComprasService.ClearCarroAsync();


            return View("CheckoutComplete");
        }


        public async Task<IActionResult> MyOrder()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var vendas = await _IGuardarVendas.GetAllVendasAsync(userId);
            return View(vendas);
        }
    }
}