﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int Price { get; set; }
 
        public int BrandId { get; set; }
    
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }
    }

}
