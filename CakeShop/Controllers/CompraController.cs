using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using CakeShop.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using db_ef.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace CakeShop.Controllers
{
    public class CompraController : Controller
    {

        private readonly CakeShopDbContext _context;

        public CompraController(CakeShopDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {

            List<Compra> listaCompras = new List<Compra>();

            listaCompras = _context.Compras.Include(art => art.Id_Compra).ToList();

            return View(listaCompras);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            int Id = (int)id;

            Compra compra = _context.Compras.Where(a => a.Id_Compra == id).First();

            if (compra == null)
            {

                return NotFound();

            }

            return View(compra);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Compra compra = new Compra();


            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Compra compra)
        {

            if (ModelState.IsValid)
            {

                _context.Compras.Add(compra);

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(compra);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Compra compra = new Compra();

            compra = _context.Compras.Where(a => a.Id_Compra == id).First();
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Compra compra)
        {
            if (id != compra.Id_Compra)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Compras.Update(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compra);
        }
    }
}
