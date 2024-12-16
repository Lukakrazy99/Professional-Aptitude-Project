using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Models

{
    //https://jqueryvalidation.org/documentation/
    [Table("Cassificacoes")]
    public class Classificacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Classificacao { get; set; }

        [Required]
        [ForeignKey("RegisterViewModel")]
        public int Username { get; set; } 

        [Required]
        [Display(Name = "Rating from 1 to 5")]
        public int rate { get; set; }
    }
}

