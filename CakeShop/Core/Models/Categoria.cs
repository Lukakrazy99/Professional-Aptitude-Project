using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace CakeShop.Core.Models

{
    //https://jqueryvalidation.org/documentation/
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Categoria { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public ICollection<Jogo> Jogos { get; set; }

        public Categoria()
        {
            Jogos = new Collection<Jogo>();
        }
    }
}

