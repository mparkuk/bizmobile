using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verastar.Models.OrderAggregate
{
    public class Address
    {
        public string Street { get; private set; }

        public string TownCity { get; private set; }

        public string County { get; private set; }

        public string PostCode { get; private set; }

        private Address() { }

        public Address(string street, string townCity, string country, string postcode)
        {
            Street = street;
            TownCity = townCity;
            County = country;
            PostCode = postcode;
        }
    }
}
