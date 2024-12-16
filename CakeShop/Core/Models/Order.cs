using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Core.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [StringLength(255)]
        [Required]
        public string PrimeiroNome { get; set; }

        [StringLength(255)]
        [Required]
        public string Apelido { get; set; }

        [StringLength(255)]
        [Required]
        public string Morada { get; set; }

        [StringLength(255)]
        [Required]
        public string Cidade { get; set; }

        [StringLength(255)]
        [Required]
        public string Pais { get; set; }

        [StringLength(7)]
        [Required]
        public string CodPostal { get; set; }

        [StringLength(13)]
        [Required]
        public int Telemovel { get; set; }

        [StringLength(9)]
        [Required]
        public int NIF { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        public decimal TotalVenda { get; set; }

        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new Collection<OrderDetail>();
        }
    }
}
