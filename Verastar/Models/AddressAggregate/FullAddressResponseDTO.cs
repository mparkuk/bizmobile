using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.AddressAggregate
{
    public class FullAddressResponseDTO
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string towncity { get; set; }
        public string district { get; set; }
        public string postcode { get; set; }

    }
}
