using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Models;
using Microsoft.EntityFrameworkCore;

namespace Verastar.Data
{
    public class TelecomContext : DbContext
    {
        public TelecomContext(DbContextOptions<TelecomContext> options) : base(options)
        {
        }

        public DbSet<MobilePhone> MobilePhones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
