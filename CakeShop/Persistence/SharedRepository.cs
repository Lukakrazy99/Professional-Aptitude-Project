using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CakeShop.Persistence
{
    public class SharedRepository : IGuardarReview
    {
        private readonly CakeShopDbContext _context;

        public SharedRepository(CakeShopDbContext context)
        {
            _context = context;
        }


      


        public void UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
        }

        public async Task AddReviewAsync(Review review)
        {
			await _context.Reviews.AddAsync(review);

		}

        //public void DeleteJogo(int id)
        //{
        //    var jogo = new Jogo { Id_Jogo = id };
        //    _context.Entry(jogo).State = EntityState.Deleted;
        //}
    }
    
    
}
