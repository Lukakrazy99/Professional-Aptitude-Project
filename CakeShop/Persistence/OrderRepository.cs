using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CakeShop.Persistence
{
    public class OrderRepository : IGuardarVendas
    {
        private readonly CakeShopDbContext _context;
        private readonly ICarroComprasService _carroComprasService;

        public OrderRepository(
            CakeShopDbContext context,
            ICarroComprasService carroComprasService)
        {
            _context = context;
            _carroComprasService = carroComprasService;
        }

        public async Task CreateVendasAsync(Order order)
        {
            order.Data = DateTime.Now;
            await _context.Orders.AddAsync(order);

            var carroComprasItems = await _carroComprasService.GetCarroComprasItemsAsync();
            order.TotalVenda = (await _carroComprasService.GetCarroCountAndTotalAmmountAsync()).TotalAmmount;

            await _context.OrderDetails.AddRangeAsync(carroComprasItems.Select(e => new OrderDetail
            {
                Qnt = e.Qnt,
                Nomejogo = e.jogo.Nome,
                OrderId = order.Id,
                Preco = e.jogo.Preco
            }));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MinhasVendasViewModel>> GetAllVendasAsync()
        {
            return await _context.Orders
                .Include(e => e.OrderDetails)
                .Select(e => new MinhasVendasViewModel
                {
                    Data = e.Data,
                    TotalVenda = e.TotalVenda,
                    vendadetalhes = new VendaDetalhes
                    {
                        Morada = e.Morada,
                        Cidade = e.Cidade,
                        Pais = e.Pais,
                        NIF = e.NIF,
                        PrimeiroNome = e.PrimeiroNome,
                        Apelido = e.Apelido,
                        Telemovel = e.Telemovel,
                        CodPostal = e.CodPostal
                    },
                    InfosVendaJogo = e.OrderDetails.Select(o => new InfoVendaJogo
                    {
                        Nome = o.Nomejogo,
                        Preco = o.Preco,
                        Qnt = o.Qnt
                    })
                })
                .ToListAsync();

        }
        public async Task<IEnumerable<MinhasVendasViewModel>> GetAllVendasAsync(string userId)
        {
            return await _context.Orders
                .Where(e => e.UserId == userId)
                .Include(e => e.OrderDetails)
                .Select(e => new MinhasVendasViewModel
                {
                    Data = e.Data,
                    TotalVenda = e.TotalVenda,
                    vendadetalhes = new VendaDetalhes
                    {
                        Morada = e.Morada,
                        Cidade = e.Cidade,
                        Pais = e.Pais,
                        NIF = e.NIF,
                        PrimeiroNome = e.PrimeiroNome,
                        Apelido = e.Apelido,
                        Telemovel = e.Telemovel,
                        CodPostal = e.CodPostal
                    },
                    InfosVendaJogo = e.OrderDetails.Select(o => new InfoVendaJogo
                    {
                        Nome = o.Nomejogo,
                        Preco = o.Preco,
                        Qnt = o.Qnt
                    })
                })
                .ToListAsync();
        }
    }
}
