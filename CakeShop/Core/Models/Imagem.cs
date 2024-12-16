using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CakeShop.Core.Models
{ 
    //https://jqueryvalidation.org/documentation/

    [Table("Imagens")]
    public class Imagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Imagem { get; set; }

        [Required]
        [ForeignKey("Capitulos")]
        public int Id_Capitulo { get; set; }

        [Required]
        [Display(Name = "Images")]
        [StringLength(255)]
        public string imagem { get; set; }
    }
}
