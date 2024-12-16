using CakeShop.Core.Models;
using CakeShop.Core.Dto;
using System.Collections.Generic;

namespace CakeShop.Core.ViewModel
{
    public class JogoListViewModel
    {
        public IEnumerable<Jogo> Jogos { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Plataforma> Plataformas { get; set; }
        public JogoListViewModel()
        {
            Categorias = new List<Categoria>();
            Plataformas = new List<Plataforma>();
        }
        public string CurrentCategory { get; set; }
        public string CurrentPlataforma { get; set; }
    }
}
