﻿using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CakeShop.Persistence
{
    public class CategoryRepository : IGuardarCategorias
    {
        private readonly CakeShopDbContext _context;

        public CategoryRepository(CakeShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategories()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
