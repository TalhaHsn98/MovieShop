using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Purchases")]
    public class Purchase
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime PurchaseDateTime { get; set; }
        [Required]
        public Guid PurchaseNumber { get; set; }
        [Required, Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }
        public Movie? Movie { get; set; }
        public User? User { get; set; }
    }
}
