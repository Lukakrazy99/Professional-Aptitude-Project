using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace db_ef.ViewModels
{

    public class JogoViewModel
    {
        public Jogo jogo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

    }
   
}
