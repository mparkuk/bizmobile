using Microsoft.EntityFrameworkCore;
using Verastar.Models;
using Verastar.Models.OrderAggregate;

namespace Verastar.Data
{
    public class TelecomContext : DbContext
    {
        public TelecomContext(DbContextOptions<TelecomContext> options) : base(options)
        {
        }

        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> OrderAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
