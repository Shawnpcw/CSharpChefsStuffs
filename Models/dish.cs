using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace chefsstuffs.Models
{
    public class Dish
    {
        [Key]
        public int id {get;set;}
       
        [Required(ErrorMessage = "Chef name is Required")]
        [MinLength(2,ErrorMessage = "Dish's name must be greater than 3 characters")]
        [MaxLength(20,ErrorMessage = "Dish's name must be less than 20 characters")]
        [DataType(DataType.Text)]
        public string dishName { get; set; }
        [Required(ErrorMessage = "Calories amount is Required")]
        [Range(0,10000,ErrorMessage = "Calories must be between 0, 10,000")]
        
        
        public int calories { get; set; }
        [Required(ErrorMessage = "Taste Level is Required")]
        [Range(1,5,ErrorMessage = "Taste Level must be between 1, 5")]
        [DataType(DataType.Text)]
        public int tasteLevel { get; set; }
        [MaxLength(244,ErrorMessage = "Description must be less than 244 charaters")]
        public string description { get; set; }

        public int ChefId {get;set;}
        // [ForeignKey("chefId")]
        public Chef Chef {get;set;}

    }
}