using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewSystem.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(6)]
        public string Gender { get; set; }

        public List<Product> Product { get; set; } = new List<Product>();

        public List<Review> Review { get; set; } = new List<Review>();
    }
}
