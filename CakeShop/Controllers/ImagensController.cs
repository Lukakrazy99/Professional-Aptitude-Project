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
    public class ImagensController : Controller
    {

        private readonly CakeShopDbContext _context;

        public ImagensController(CakeShopDbContext context)
        {

            _context = context;

        }

        public IActionResult Index()
        {

            List<Imagem> listaImagens = new List<Imagem>();

            listaImagens = _context.Imagems.Include(art => art.Id_Imagem).ToList();

            return View(listaImagens);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            int Id = (int)id;

            Imagem imagem = _context.Imagems.Where(a => a.Id_Imagem == id).First();

            if (imagem == null)
            {

                return NotFound();

            }

            return View(imagem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Imagem imagem = new Imagem();


            return View(imagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Imagem imagem)
        {

            if (ModelState.IsValid)
            {

                _context.Imagems.Add(imagem);

                _context.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(imagem);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Imagem imagem = new Imagem();

            imagem = _context.Imagems.Where(a => a.Id_Imagem == id).First();
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Imagem imagem)
        {
            if (id != imagem.Id_Imagem)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {  
                _context.Imagems.Update(imagem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagem);
        }
    }
}
