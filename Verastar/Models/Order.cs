using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AgreeTerms { get; set; }
        public OrderAggregate.Address Address { get; set; }
    }
}
