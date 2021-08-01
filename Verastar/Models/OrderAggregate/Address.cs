using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.OrderAggregate
{
    public class Address
    {
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public string TownCity { get; private set; }
        public string District { get; private set; }
        public string PostCode { get; private set; }

    }
}
