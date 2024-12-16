using CakeShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Persistence
{
    public class CakeShopDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<CarroComprasItem> CarroComprasItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Classificacao> Classificacaos { get; set; }
        public DbSet<Compra> Compras{ get; set; }
        public DbSet<Funcionario> Funcionarios{ get; set; }
        public DbSet<Imagem> Imagems{ get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }

        public CakeShopDbContext(DbContextOptions<CakeShopDbContext> options)
            : base(options)
        {

        }
    }
}
