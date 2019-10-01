using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
