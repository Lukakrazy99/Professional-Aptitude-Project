using CakeShop.Core.Models;
using System.Collections.Generic;

namespace CakeShop.Core.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Jogo> Jogos { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Plataforma> Plataformas { get; set; }
        public HomeViewModel()
        {
            Categorias = new List<Categoria>();
            Plataformas = new List<Plataforma>();
        }
        public string CurrentCategory { get; set; }
        public string CurrentPlataforma { get; set; }
    }
}
