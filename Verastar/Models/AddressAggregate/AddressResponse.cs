using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.AddressAggregate
{
    public class AddressResponse
    {
        public IEnumerable<AddressSuggestion> suggestions { get; set; }
    }
}
