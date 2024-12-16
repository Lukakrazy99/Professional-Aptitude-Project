using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Dto
{
    public class VendaDetalhes
    {
        [Display(Name = "Primeiro Nome")]
        [Required(ErrorMessage = "Tens de preencher o teu nome")]
        public string PrimeiroNome { get; set; }
        
        [Display(Name = "Apelido")]
        [Required(ErrorMessage = "Tens de introduzir o teu apelido")]
        public string Apelido { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Deverás introduzir uma cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Código Postal")]
        [Required(ErrorMessage = "Qual é o Código Postal?")]
        public string CodPostal { get; set; }

        [Display(Name = "NIF")]
        [Required(ErrorMessage = "NIF necessário")]
        public int NIF { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "Você deve selecionar um país")]
        public string Pais { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "É uma rua? Uma avenida?")]
        public string Morada { get; set; }

        [Display(Name = "Número de telemóvel")]
        [Required(ErrorMessage = "Poderá ser útil para o transportador…")]
        public int Telemovel { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Email necessário")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
