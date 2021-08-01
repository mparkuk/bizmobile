using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Core.IRepositories;
using Verastar.Data;
using Verastar.Models;

namespace Verastar.Core.Repository
{
    public class MobilePhoneRepository : GenericRepository<MobilePhone>, IMobilePhoneRepository
    {
        public MobilePhoneRepository(TelecomContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<MobilePhone>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(MobilePhoneRepository));
                return new List<MobilePhone>();
            }
        }

        public override async Task<bool> Upsert(MobilePhone entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.Name = entity.Name;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(MobilePhoneRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(MobilePhoneRepository));
                return false;
            }
        }
    }
}
