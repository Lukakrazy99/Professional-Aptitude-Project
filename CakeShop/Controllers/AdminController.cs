using AutoMapper;
using CakeShop.Core;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/admin/manageJogos")]
    public class AdminController : Controller
    {
        private readonly IGuardarVendas _guardarVendas;
        private readonly IGuardarJogos _guardarJogos;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGuardarCategorias _guardarCategorias;
        private readonly IGuardarPlataformas _guardarPlataformas;
        public AdminController(
            IGuardarVendas guardarVendas,
            IGuardarJogos guardarJogos,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IGuardarCategorias guardarCategorias,
            IGuardarPlataformas guardarPlataformas)
        {
            _guardarVendas = guardarVendas;
            _guardarJogos = guardarJogos;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _guardarCategorias = guardarCategorias;
            _guardarPlataformas = guardarPlataformas;
        }

        [HttpGet("allOrders")]
        public async Task<IActionResult> AllOrders()
        {
            ViewBag.ActionTitle = "All Orders";
            var orders = await _guardarVendas.GetAllVendasAsync();
            return View(orders);
        }

        [HttpGet("")]
        public async Task<IActionResult> ManageJogos()
        {
            var jogos = await _guardarJogos.GetAllJogosNomeId();
            return View(jogos);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddJogo()
        {
            var categories = await _guardarCategorias.GetCategories();
            var plataforma = await _guardarPlataformas.GetPlataforma();
            return View(new JogoCreateUpdateViewModel
            {
                Categorias = categories,
                Plataformas = plataforma
            });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddJogo(JogoDetalhes jogodetalhes)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _guardarCategorias.GetCategories();
                var plataforma = await _guardarPlataformas.GetPlataforma();
                return View(new JogoCreateUpdateViewModel
                {
                    JogoDetalhes = jogodetalhes,
                    Categorias = categorias,
                    Plataformas = plataforma
                });
            }
            var jogo = _mapper.Map<JogoDetalhes, Jogo>(jogodetalhes);
            await _guardarJogos.AddJogoAsync(jogo);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("ManageJogos");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> EditJogo(int id)
        {
            var jogo = await _guardarJogos.GetJogoById(id);
            var jogodetalhes = _mapper.Map<Jogo, JogoDetalhes>(jogo);
            var categorias = await _guardarCategorias.GetCategories();
            var plataforma = await _guardarPlataformas.GetPlataforma();

            return View(new JogoCreateUpdateViewModel
            {
                Categorias = categorias,
                JogoDetalhes = jogodetalhes,
                Plataformas = plataforma
            });
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditJogo(int id, [FromForm] JogoDetalhes jogodetalhes)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _guardarCategorias.GetCategories();
                var plataforma = await _guardarPlataformas.GetPlataforma();
                return View(new JogoCreateUpdateViewModel
                {
                    Categorias = categorias,
                    JogoDetalhes = jogodetalhes,
                    Plataformas = plataforma
                });
            }
            var jogo = _mapper.Map<JogoDetalhes, Jogo>(jogodetalhes);
            jogo.Id_Jogo = id;
            _guardarJogos.UpdateJogo(jogo);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction("ManageJogos");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogos(int id)
        {
            _guardarJogos.DeleteJogo(id);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    }

}