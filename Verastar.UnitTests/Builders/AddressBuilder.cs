using System;
using System.Collections.Generic;
using System.Text;
using Verastar.Models.OrderAggregate;

namespace Verastar.UnitTests.Builders
{
    class AddressBuilder
    {

        private Address _address;
        public string TestStreet => "111 Fairywell Road";
        public string TestTownCity => "Timperley, Altrincham";
        public string TestCounty => "Cheshire";
        public string TestPostCode => "WA15 6XD";

        public AddressBuilder()
        {
            _address = WithDefaultValues();
        }
        public Address Build()
        {
            return _address;
        }
        public Address WithDefaultValues()
        {
            _address = new Address(TestStreet, TestTownCity, TestCounty, TestPostCode);
            return _address;
        }
    }
}
