using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string MonthOfExpiry { get; set; }
        public string YearOfExpiry { get; set; }
        public string CVV { get; set; }


    }
}
