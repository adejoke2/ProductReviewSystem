using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviewSystem.Models.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string Comment { get; set; }

        public int Ratings { get; set; }

        public string UserName { get; set; }

        public string ProductName { get; set; }
    }

    public class ProductIndexViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int Ratings { get; set; }

        public string UserName { get; set; }

        public string ProductName { get; set; }
    }

    public class SelectUserViewModel
    {
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "User Name:")]
        public int UserId { get; set; }

    }

    public class CreateReviewViewModel
    {
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "User Name:")]
        public int UserId { get; set; }

       
        [Required(ErrorMessage = "You must fill out this field!")]
        [Display(Name = "Product Name:")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please make a Comment!!")]
        [Display(Name = "Comment Section:")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public int Ratings { get; set; }
    }
    public class UpdateReviewViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please make a Comment!!")]
        [Display(Name = "Comment Section:")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Rate Us Here!")]
        [Range(1, 5)]
        public int Ratings { get; set; }
    }
}
