using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsstuffs.Models
{
    public class Chef
    {
        [Key]
        public int id {get;set;}

        [Required(ErrorMessage = "Chef name is Required")]
        [MinLength(2,ErrorMessage = "Chef's name must be greater than 3 characters")]
        [MaxLength(20,ErrorMessage = "Chef's name must be less than 20 characters")]
        [DataType(DataType.Text)]
        public string name {get;set;}
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Must include the DOB.")]        
        public DateTime DOB {get;set;} 
        // [ForeignKey("chefId")]
        public List<Dish> Dishes {get;set;}               
    }
}