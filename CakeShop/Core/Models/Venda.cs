using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Models
{
    //https://jqueryvalidation.org/documentation/
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Venda { get; set; }

        [Required]
        [ForeignKey("Jogo")]
        public int Id_Jogo { get; set; }

        [Required]
        [ForeignKey("Clientes")]
        public int Id_Cliente { get; set; } 

        [Required]
        [Display(Name = "Price")]
        public decimal Preço { get; set; }

        [Required]
        [Display(Name = "Sale Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dt_Venda { get; set; }
    }
}

