﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084ClassDEMO.Models
{
    public class Product
    {
        public int Id { get; set; }
   
        public string Name { get; set; }

        public double Price { get; set; }
        
        public int CategoryId { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        //reference the parent class (1 Category - Many Products)
        public Category Category { get; set; }
    }
}
