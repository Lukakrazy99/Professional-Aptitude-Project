using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using CakeShop.Persistence;
using CakeShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using db_ef.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Security.Claims;
using System.IO;

namespace CakeShop.Controllers
{
    [Route("/jogos")]
    public class JogoController : Controller
    {

        private readonly IGuardarJogos _guardarJogos;
        private readonly IGuardarCategorias _guardarCategorias;
		private readonly IGuardarPlataformas _guardarPlataformas;

		private readonly CakeShopDbContext _context;

		//public JogoController(CakeShopDbContext context)
		//{

		//	_context = context;


		//}

		public JogoController(CakeShopDbContext context, IGuardarJogos guardarJogos, IGuardarCategorias guardarCategorias, IGuardarPlataformas guardarPlataformas)
        {
            _guardarJogos = guardarJogos;
            _guardarCategorias = guardarCategorias;
			_guardarPlataformas = guardarPlataformas;
			_context = context;

		}
		//if(Plataforma)
		[HttpGet("{plataforma?}/{categoria?}")]
		public async Task<IActionResult> ListPlat(int id, string plataforma, string categoria)
		{
			var selectedPlataforma = !string.IsNullOrWhiteSpace(plataforma) ? plataforma : null;
            var selectedCategoria = !string.IsNullOrWhiteSpace(categoria) ? categoria : null;
            var JogoListViewModel = new JogoListViewModel
			{
				Jogos = await _guardarJogos.GetJogosCateg(selectedPlataforma, selectedCategoria),
				CurrentPlataforma = selectedPlataforma ?? "Todos os Jogos"
			};
			return View(JogoListViewModel);
		}
	

		[HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

			SharedService service = new SharedService(_context);


			var JogoDetailsViewModel = new JogoDetailsViewModel
			{
				jogo = await _guardarJogos.GetJogoById(id),
				Review =  service.GetReview(id)
			};
			return View(JogoDetailsViewModel);

		}
		//public IActionResult Details()
		//{

		//	List<Review> listaReviews = new List<Review>();

		//	listaReviews = _context.Reviews.Include(art => art.JogoId).ToList();

		//	return View(listaReviews);

		//}
	}
}
