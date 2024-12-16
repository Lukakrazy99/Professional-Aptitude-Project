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
    public class VendaController : Controller
    {

        private readonly CakeShopDbContext _context;

        public VendaController(CakeShopDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {

            List<Venda> listvenda = new List<Venda>();

            listvenda = _context.Vendas.Include(art => art.Id_Venda).ToList();

            return View(listvenda);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            int Id = (int)id;

            Venda venda = _context.Vendas.Where(a => a.Id_Venda == id).First();

            if (venda == null)
            {

                return NotFound();

            }

            return View(venda);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Venda venda = new Venda();


            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Venda venda )
        {

            if (ModelState.IsValid)
            {

                _context.Vendas.Add(venda);

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(venda);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Venda venda = new Venda();

            venda = _context.Vendas.Where(a => a.Id_Venda == id).First();
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Venda venda)
        {
            if (id != venda.Id_Venda)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  
                _context.Vendas.Update(venda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }
    }
}
