using CakeShop.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Persistence
{
    public class CarroComprasService : ICarroComprasService
    {
        private readonly CakeShopDbContext _context;

        public string Id { get; set; }
        public IEnumerable<CarroComprasItem> CarroComprasItems { get; set; }

        private CarroComprasService(CakeShopDbContext context)
        {
            _context = context;
        }

        public static CarroComprasService GetCart(IServiceProvider services)
        {
            var httpContext = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
            var context = services.GetRequiredService<CakeShopDbContext>();

            var request = httpContext.Request;
            var response = httpContext.Response;

            var cardId = request.Cookies["CartId-cookie"] ?? Guid.NewGuid().ToString();

            response.Cookies.Append("CartId-cookie", cardId, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(2)
            });

            return new CarroComprasService(context)
            {
                Id = cardId
            };
        }

        public async Task<int> AddToCarroAsync(Jogo jogo, int qnt = 1)
        {
            return await AddOrRemoveCarro(jogo, qnt);

        }

        public async Task<int> RemoveFromCarroAsync(Jogo jogo)
        {
            return await AddOrRemoveCarro(jogo, -1);
        }

        public async Task<IEnumerable<CarroComprasItem>> GetCarroComprasItemsAsync()
        {
            CarroComprasItems = CarroComprasItems ?? await _context.CarroComprasItems
                .Where(e => e.CarroComprasId == Id)
                .Include(e => e.jogo)
                .ToListAsync();

            return CarroComprasItems;
        }

        public async Task ClearCarroAsync()
        {
            var carroComprasItems = _context
                .CarroComprasItems
                .Where(s => s.CarroComprasId == Id);

            _context.CarroComprasItems.RemoveRange(carroComprasItems);

            CarroComprasItems = null; //reset
            await _context.SaveChangesAsync();
        }

        public async Task<(int ItemCount, decimal TotalAmmount)> GetCarroCountAndTotalAmmountAsync()
        {
            var subTotal = CarroComprasItems?
                .Select(c => c.jogo.Preco * c.Qnt) ??
                await _context.CarroComprasItems
                .Where(c => c.CarroComprasId == Id)
                .Select(c => c.jogo.Preco * c.Qnt)
                .ToListAsync();

            return (subTotal.Count(), subTotal.Sum());
        }

        private async Task<int> AddOrRemoveCarro(Jogo jogo, int qnt)
        {


            var carroComprasItems = await _context.CarroComprasItems
                            .SingleOrDefaultAsync(s => s.JogoId == jogo.Id_Jogo && s.CarroComprasId == Id);

            if (carroComprasItems == null)
            {
                carroComprasItems = new CarroComprasItem
                {
                    CarroComprasId = Id,
                    jogo = jogo,
                    Qnt = 0
                };

                await _context.CarroComprasItems.AddAsync(carroComprasItems);
            }

            carroComprasItems.Qnt += qnt;

            if (carroComprasItems.Qnt <= 0)
            {
                carroComprasItems.Qnt = 0;
                _context.CarroComprasItems.Remove(carroComprasItems);
            }

            await _context.SaveChangesAsync();

            this.CarroComprasItems = null; // Reset

            return await Task.FromResult(carroComprasItems.Qnt);
        }

    }
}
