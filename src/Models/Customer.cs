using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set;}

        public string MobileNumber  { get; set; }
        public string Email { get; set;}
    }
}