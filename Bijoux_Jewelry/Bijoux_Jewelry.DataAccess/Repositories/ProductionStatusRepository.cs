using Bijoux_Jewelry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductionStatusRepository
    {
        DiamondShopDbContext _context;

        public List<ProductionStatus> getAll()
        {
            _context = new();
            return _context.ProductionStatuses.ToList();
        }
    }
}
