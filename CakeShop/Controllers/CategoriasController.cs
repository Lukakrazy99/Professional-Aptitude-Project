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

namespace CakeShop.Controllers
{
    public class PlataformasController : Controller
    {

        private readonly CakeShopDbContext _context;

        public PlataformasController(CakeShopDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {

            List<Categoria> listaCategorias = new List<Categoria>();

            listaCategorias = _context.Categorias.Include(art => art.Nome).ToList();

            return View(listaCategorias);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            int Id = (int)id;

            Categoria categoria = _context.Categorias.Where(a => a.Id_Categoria == id).First();

            if (categoria == null)
            {

                return NotFound();

            }

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Categoria categoria = new Categoria();


            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Categoria categoria)
        {

            if (ModelState.IsValid)
            {

                _context.Categorias.Add(categoria);

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(categoria);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categoria categoria = new Categoria();

            categoria = _context.Categorias.Where(a => a.Id_Categoria == id).First();
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Categoria categoria)
        {
            if (id != categoria.Id_Categoria)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
    }
}
