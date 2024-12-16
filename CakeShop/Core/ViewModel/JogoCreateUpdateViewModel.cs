using System.Collections.Generic;
using CakeShop.Core.Models;
using CakeShop.Core.Dto;

namespace CakeShop.Core.ViewModel
{
    public class JogoCreateUpdateViewModel
    {
        public IEnumerable<Categoria> Categorias { get; set; }
        public IEnumerable<Plataforma> Plataformas { get; set; }
        public JogoDetalhes JogoDetalhes { get; set; }

        public JogoCreateUpdateViewModel()
        {
            Categorias = new List<Categoria>();
            Plataformas = new List<Plataforma>();
        }
    }
}
