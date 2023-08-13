using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Brand
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        [StringLength(100, MinimumLength =3)]
        public string Name { get; set; }
        [StringLength(500, MinimumLength =5)]
        public string Description { get; set; }
        public DateTime EstablishedDate { get; set; }

        public ICollection<Product> Products { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }

    }
}
