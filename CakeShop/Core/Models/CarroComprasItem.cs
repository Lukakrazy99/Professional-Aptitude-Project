using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Models
{
	public class CarroComprasItem
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Qnt { get; set; }

        public int JogoId { get; set; }

        public Jogo jogo { get; set; }

        [Required]
        [StringLength(255)]
        public string CarroComprasId { get; set; }
    }
}
