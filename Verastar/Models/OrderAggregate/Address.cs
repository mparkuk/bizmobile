using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.OrderAggregate
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string TownCity { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }

    }
}
