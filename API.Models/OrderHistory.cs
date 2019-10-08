using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Models
{
    public class OrderHistory
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Users User { get; set; }

        public int Quantity { get; set; }


        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
        public int ProductTotal { get; set; }

        public virtual Products Product { get; set; }
    }
}
