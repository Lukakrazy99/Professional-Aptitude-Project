using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using CakeShop.Persistence;

using System.Linq;


namespace CakeShop.Services
{
    public class SharedService 
    {
		private readonly CakeShopDbContext _context;

		public SharedService(CakeShopDbContext context)
		{

			_context = context;

		}
		public bool LeaveReview(Review review)
		{

			
			_context.Reviews.Add(review);

			return _context.SaveChanges() > 0;


		}
		public List<Review> GetReview(int jogoid)
		{
			return _context.Reviews.Where(e => e.JogoId == jogoid).ToList();
		}

	}
}
