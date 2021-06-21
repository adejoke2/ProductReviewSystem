using System.ComponentModel.DataAnnotations;

namespace ProductReviewSystem.Models
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required, MaxLength(250)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public int Ratings { get; set; }

    }
}