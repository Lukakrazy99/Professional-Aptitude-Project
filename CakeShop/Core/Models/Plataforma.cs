using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
namespace CakeShop.Core.Models
{
    [Table("Plataformas")]
    public class Plataforma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Plataforma { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public ICollection<Jogo> Jogos { get; set; }

        public Plataforma()
        {
            Jogos = new Collection<Jogo>();
        }
    }
}
