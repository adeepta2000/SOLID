using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        [ForeignKey("Brands")]
        public int BrandId { get; set; }
        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public string BrandName { get; set; }

        public virtual Brand Brands { get; set; }
        public virtual Category Categories { get; set; }
    }
}
