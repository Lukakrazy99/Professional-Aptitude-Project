using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Persistence
{
    public class PlataformaRepository : IGuardarPlataformas
    {
        private readonly CakeShopDbContext _context;

        public PlataformaRepository(CakeShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plataforma>> GetPlataforma()
        {
            return await _context.Plataformas.ToListAsync();
        }
    }
}
