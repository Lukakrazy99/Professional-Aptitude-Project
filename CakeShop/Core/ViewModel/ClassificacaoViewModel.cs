using CakeShop.Core.Models;
using CakeShop.Core.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CakeShop.Core.ViewModel
{
    public class ClassificacaoViewModel
    {
        public Classificacao Classificacaos { get; set; }
        public IEnumerable<SelectListItem> Clientes { get; set; }
    }
}
