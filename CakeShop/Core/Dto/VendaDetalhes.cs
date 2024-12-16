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
        [Required(ErrorMessage = "Dever�s introduzir uma cidade")]
        public string Cidade { get; set; }

        [Display(Name = "C�digo Postal")]
        [Required(ErrorMessage = "Qual � o C�digo Postal?")]
        public string CodPostal { get; set; }

        [Display(Name = "NIF")]
        [Required(ErrorMessage = "NIF necess�rio")]
        public int NIF { get; set; }

        [Display(Name = "Pa�s")]
        [Required(ErrorMessage = "Voc� deve selecionar um pa�s")]
        public string Pais { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "� uma rua? Uma avenida?")]
        public string Morada { get; set; }

        [Display(Name = "N�mero de telem�vel")]
        [Required(ErrorMessage = "Poder� ser �til para o transportador�")]
        public int Telemovel { get; set; }


        [StringLength(255)]
        [Required(ErrorMessage = "Email necess�rio")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
