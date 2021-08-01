using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verastar.Core.IRepositories;

namespace Verastar.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }

        Task CompleteAsync();
    }
}
