using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Reviews")]
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required, Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }
        [Required]
        public string ReviewText { get; set; } = string.Empty;
        public Movie? Movie { get; set; }
        public User? User { get; set; }
    }
}
