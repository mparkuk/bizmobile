using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Verastar.Core.IConfiguration;
using Verastar.Core.IRepositories;
using Verastar.Core.Repository;

namespace Verastar.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TelecomContext _context;
        private readonly ILogger _logger;

        public IOrderRepository Orders { get; private set; }
        public IMobilePhoneRepository MobilePhones { get; private set; }

        public UnitOfWork(TelecomContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Orders = new OrderRepository(_context, _logger);
            MobilePhones = new MobilePhoneRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
