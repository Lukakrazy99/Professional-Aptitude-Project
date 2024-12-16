using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.Core.Dto;

namespace CakeShop.Core.Models
{
    public interface IGuardarJogos
    {
        Task<IEnumerable<Jogo>> GetJogos(string plataforma = null);
        Task<IEnumerable<Jogo>> GetJogosCateg(string plataforma = null, string categoria = null);
        Task<Jogo> GetJogoById(int jogoId);
        List<Review> GetReview(int jogoId);
        Task<IEnumerable<NomeJogoIdDetalhes>> GetAllJogosNomeId();

        void UpdateJogo(Jogo jogo);
        Task AddJogoAsync(Jogo jogo);
        void DeleteJogo(int id);
    }
}
