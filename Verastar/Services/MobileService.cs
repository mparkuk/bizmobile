using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Data;
using Verastar.Models;

namespace Verastar.Services
{
    public interface IMobileService
    {
        Task<List<MobilePhone>> GetMobileDataAsync();
    }

    public class MobileService : IMobileService
    {
        private readonly TelecomContext _context;

        public MobileService(TelecomContext context)
        {
            _context = context;
        }

        public async Task<List<MobilePhone>> GetMobileDataAsync()
        {
            return await _context.MobilePhones
                .OrderByDescending(m => m.LastUpdated)
                .ToListAsync();
        }

        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first.");
        }

        // Get mobile phone information from external source

    }
}
