using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CakeShop.Core.Dto;
using CakeShop.Core.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeShop.Core.ViewModel
{

    public class ReviewViewModel
    {
        public string Text { get; set; }
        public int Id_Review { get; set; }
        public int JogoId { get; set; }

    }
   
}
