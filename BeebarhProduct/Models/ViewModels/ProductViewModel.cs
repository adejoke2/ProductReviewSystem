using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewSystem.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public double AverageRating { get; set; }
    }

    public class CreateProductViewModel
    {
        [Required(ErrorMessage="Product name is required")]
        [Display(Name="Product Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage="Product Description is required")]
        [Display(Description="Product Description:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product Manufacturer name is required")]
        [Display(Name = "Manufacturer Name")]
        public int UserId { get; set; }

        public string Username { get; set; }

        public User User { get; set; }
    }

    public class UpdateProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is required")]
        [Display(Description = "Product Description:")]
        public string Description { get; set; }

        public User User { get; set; }
    } 
}