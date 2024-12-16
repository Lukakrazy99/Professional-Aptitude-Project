using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CakeShop.Persistence;
using Microsoft.AspNetCore.Identity;

namespace CakeShop.Core.Models

{
    //https://jqueryvalidation.org/documentation/
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome_Completo { get; set; }

        public string UsertId { get; set; }
        public IdentityUser User { get; set; }
    }
}

