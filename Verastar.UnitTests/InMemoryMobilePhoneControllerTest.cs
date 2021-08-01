using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Verastar.Data;

namespace Verastar.UnitTests
{
    public class InMemoryMobilePhoneControllerTest : MobilePhoneControllerTest
    {
        public InMemoryMobilePhoneControllerTest()
            : base(
                new DbContextOptionsBuilder<TelecomContext>()
                    .UseInMemoryDatabase("TestDatabase")
                    .Options)
        {
        }
    }
}
