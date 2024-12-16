using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CakeShop.Core.Dto
{
    public partial class JogoDetalhes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public int Preco { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }


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

        
        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Required]
        [Display(Name = "Plataforma")]
        public int? PlataformaId { get; set; }

      
    }
}
