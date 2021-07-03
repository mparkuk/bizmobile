using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Models;

namespace Verastar.Data
{
    public class DbInitializer
    {
        public static void Initialize(TelecomContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.MobilePhones.Any())
            {
                return;   // DB has been seeded
            }

            var mobiles = new MobilePhone[]
            {
            new MobilePhone{Name="S10", Manufacture="Samsung", LastUpdated=DateTime.Now, ImagePath="/images/samsung-galaxy-s10.jpg" },
            new MobilePhone{Name="S21", Manufacture="Samsung", LastUpdated=DateTime.Now, ImagePath="/images/samsung-galaxy-s21-5g-r.jpg" },
            new MobilePhone{Name="iPhone 11", Manufacture="Apple", LastUpdated=DateTime.Now, ImagePath="/images/apple-iphone-11.jpg" }
            };
            foreach (MobilePhone m in mobiles)
            {
                context.MobilePhones.Add(m);
            }
            context.SaveChanges();

        }
    }
}
