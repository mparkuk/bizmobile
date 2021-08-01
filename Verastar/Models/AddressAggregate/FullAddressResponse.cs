using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.AddressAggregate
{
    public class FullAddressResponse
    {
        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string town_or_city { get; set; }
        public string district { get; set; }
        public string postcode { get; set; }

    }
}
