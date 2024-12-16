using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CakeShop.Persistence
{
    public class JogoRepository : IGuardarJogos
    {
        private readonly CakeShopDbContext _context;

        public JogoRepository(CakeShopDbContext context)
        {
            _context = context;
        }


        public async Task<Jogo> GetJogoById(int jogoid)
        {
            return await _context.Jogos.FirstAsync(e => e.Id_Jogo == jogoid);
        }
        public List<Review> GetReview(int jogoid)
        {
            return _context.Reviews.Where(e => e.JogoId == jogoid).ToList();
        }

        public async Task<IEnumerable<Jogo>> GetJogos(string plataforma = null)
        {

            var query = _context.Jogos
                .Include(c => c.Plataforma)
                .AsQueryable();

            
                query = query.Where(c => c.Plataforma.Nome == plataforma);
            

            return await query.ToListAsync();
        }

        
        public async Task<IEnumerable<Jogo>> GetJogosCateg(string plataforma = null, string categoria = null)
        {

            var query = _context.Jogos
                .Include(c => c.Plataforma)
                .Include(c => c.Categoria)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(plataforma))
            {
                            
            if (categoria == null)
			{
                query = query.Where(c => c.Plataforma.Nome == plataforma);
                return await query.ToListAsync();
            }
               query = query.Where(c => c.Plataforma.Nome == plataforma && c.Categoria.Nome == categoria);
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<NomeJogoIdDetalhes>> GetAllJogosNomeId()
        {
            return await _context.Jogos
                 .Select(e => new NomeJogoIdDetalhes
                 {
                     Id = e.Id_Jogo,
                     Nome = e.Nome
                 })
                 .ToListAsync();
        }


        public void UpdateJogo(Jogo jogo)
        {
            _context.Jogos.Update(jogo);
        }

        public async Task AddJogoAsync(Jogo jogo)
        {
			await _context.Jogos.AddAsync(jogo);

		}

        public void DeleteJogo(int id)
        {
            var jogo = new Jogo { Id_Jogo = id };
            _context.Entry(jogo).State = EntityState.Deleted;
        }
    }
    
    
}
