using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewSystem.Models
{
    public class Product:BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(250)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Address {get; set;}

        public List<Review> Review { get; set; } = new List<Review>();
    }
}
