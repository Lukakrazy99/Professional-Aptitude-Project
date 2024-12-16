using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly  /*ICakeRepository _cakeRepository;*/ IGuardarJogos _jogoRepository;

        public HomeController(/*ICakeRepository cakeRepository */ IGuardarJogos jogoRepository) 
        {
            //_cakeRepository = cakeRepository;
            _jogoRepository = jogoRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
              
            }
            );

        
        }
    }
}