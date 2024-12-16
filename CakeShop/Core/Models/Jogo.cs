using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CakeShop.Core.Models
{
    //https://jqueryvalidation.org/documentation/


    [Table("Jogos")]
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Jogo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Preço")]
        public int Preco { get; set; }

        [Required]
        [Display (Name = "Quantidade")]
        public  int Quantidade { get; set; }


        [Required]
        [Display(Name = "Descrição")]
        public string PDescricao { get; set; }

        [Required]
        [Display(Name = "Especicações")]
        public string Especificacoes { get; set; }

        [Display(Name = "Classificação de 1 a 5")]
        public int Qualidade { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        [ForeignKey("Categoria")]
        [Required]
        public int? CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [ForeignKey("Plataforma")]
        [Required]
        public int? PlataformaId { get; set; }

        public Plataforma Plataforma { get; set; }

        //[ForeignKey("Review")]
        //[Required]
        //public int? ReviewId { get; set; }

        //public Review Review { get; set; }
    }
}
