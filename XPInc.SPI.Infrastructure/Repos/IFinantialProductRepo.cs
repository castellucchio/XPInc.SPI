using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPInc.SPI.Entities.Models;

namespace XPInc.SPI.Infrastructure.Repos
{
    public interface IFinantialProductRepo : IRepo<FinantialProduct>
    {
        Task<IEnumerable<FinantialProduct>> GetExpiringProducts();
    }
}
