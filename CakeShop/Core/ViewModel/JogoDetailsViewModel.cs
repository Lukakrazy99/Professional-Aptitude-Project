using CakeShop.Core.Models;
using CakeShop.Core.Dto;
using System.Collections.Generic;

namespace CakeShop.Core.ViewModel
{
    public class JogoDetailsViewModel
    {

        public IEnumerable<Jogo> Jogos { get; set; }
        public IEnumerable<Review> Review { get; set; }
        public Jogo jogo { get; set; }
        public Review review { get; set; }


        public JogoDetailsViewModel()
        {
            Review = new List<Review>();

            Jogos = new List<Jogo>();
        }
    }
}
