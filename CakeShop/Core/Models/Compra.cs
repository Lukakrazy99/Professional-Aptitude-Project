using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Models

{
    //https://jqueryvalidation.org/documentation/
    [Table("Compras")]
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Compra { get; set; }

        [Required]
        [ForeignKey("Jogos")]
        public int Id_Jogo { get; set; }

        [Required]
        [ForeignKey("Fornecedores")]
        public int Id_Fornecedor{ get; set; }

        [Required]
        [ForeignKey("Funcionarios")]
        public int Id_Funcionario { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Preço { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dt_Compra { get; set; }
    }
}

