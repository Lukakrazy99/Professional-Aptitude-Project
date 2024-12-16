using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using CakeShop.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using CakeShop.Services;
namespace CakeShop.Controllers
{
    public class SharedController : Controller
    {

		private readonly CakeShopDbContext _context;

		public SharedController(CakeShopDbContext context)
		{

			_context = context;


		}
		


		[HttpPost]
		public JsonResult LeaveReview(ReviewViewModel model)
		{
			
			SharedService service = new SharedService(_context);
			JsonResult result = new JsonResult(new { });
			try
			{
				var review = new Review();
				review.Text = model.Text;
				review.Id_Review = model.Id_Review;
				review.JogoId = model.JogoId;
				review.User = User.Identity.Name;
				review.TimeStamp = DateTime.Now;

				var res = service.LeaveReview(review);
				result.Value = new { Success = res };
			}
			catch (Exception ex)
			{
				result.Value = new { Success = false, Message = ex.Message };
			}




			return result;
		}



	}
}
