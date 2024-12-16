using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CakeShop.Core.Models
{
    //https://jqueryvalidation.org/documentation/


    [Table("Reviews")]
    public class Review 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id_Review { get; set; }

        //[Required]
        //[StringLength(250)]
        public string Text { get; set; }

        //[Required]       
        public string User { get; set; }

        //[Required]
        public  DateTime TimeStamp { get; set; }


        //[Required]
        public int JogoId { get; set; }

        public Jogo jogo { get; set; }


    }
}
