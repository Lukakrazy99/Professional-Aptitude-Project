using System.ComponentModel.DataAnnotations;

namespace CakeShop.Core.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nomejogo { get; set; }
        public int Qnt { get; set; }
        public decimal Preco { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
