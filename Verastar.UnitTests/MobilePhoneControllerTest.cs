using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Verastar.Data;

namespace Verastar.UnitTests
{
    public abstract class MobilePhoneControllerTest
    {
        #region Seeding
        protected MobilePhoneControllerTest(DbContextOptions<TelecomContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<TelecomContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new TelecomContext(ContextOptions))
            {

                context.Database.EnsureDeleted();

                DbInitializer.Initialize(context);

            }
        }
        #endregion

        #region CanGetItems
        //[Fact]
        //public void Can_get_items()
        //{
        //    using (var context = new ItemsContext(ContextOptions))
        //    {
        //        var controller = new ItemsController(context);

        //        var items = controller.Get().ToList();

        //        Assert.Equal(3, items.Count);
        //        Assert.Equal("ItemOne", items[0].Name);
        //        Assert.Equal("ItemThree", items[1].Name);
        //        Assert.Equal("ItemTwo", items[2].Name);
        //    }
        //}
        #endregion

    }
}
