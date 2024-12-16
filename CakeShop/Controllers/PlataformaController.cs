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
    public class PlataformaController : Controller
    {

        private readonly CakeShopDbContext _context;

        public PlataformaController(CakeShopDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {

            List<Plataforma> listaPlataformas = new List<Plataforma>();

            listaPlataformas = _context.Plataformas.Include(art => art.Nome).ToList();

            return View(listaPlataformas);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            int Id = (int)id;

            Plataforma plataforma = _context.Plataformas.Where(a => a.Id_Plataforma == id).First();

            if (plataforma == null)
            {

                return NotFound();

            }

            return View(plataforma);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Plataforma plataforma = new Plataforma();


            return View(plataforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Plataforma plataforma)
        {

            if (ModelState.IsValid)
            {

                _context.Plataformas.Add(plataforma);

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(plataforma);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Plataforma plataforma = new Plataforma();

            plataforma = _context.Plataformas.Where(a => a.Id_Plataforma == id).First();
            if (plataforma == null)
            {
                return NotFound();
            }

            return View(plataforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Plataforma plataforma)
        {
            if (id != plataforma.Id_Plataforma)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  
                _context.Plataformas.Update(plataforma);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plataforma);
        }
    }
}
