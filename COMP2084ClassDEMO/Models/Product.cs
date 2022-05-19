using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084ClassDEMO.Models
{
    public class Product
    {
        public int Id { get; set; }
   
        [Required]
        public string Name { get; set; }

        // Where ever the price is displayed format the string to currency (0 is the string, c is currency(the currency of the where the sever is located)
        [DisplayFormat(DataFormatString = "{0:c}")]
        // This is validating that we only accept data that is between the range (no neg numbers)
        [Range(0.00, 999999)]
        public double Price { get; set; }
        
        // Where ever the CategoryId is displayed we want to show it as "Category"
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        //reference the parent class (1 Category - Many Products)
        public Category Category { get; set; }
    }
}
