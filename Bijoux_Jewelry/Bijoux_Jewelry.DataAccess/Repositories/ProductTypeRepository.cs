using Bijoux_Jewelry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductTypeRepository
    {
        private DiamondShopDbContext _context;

        public List<ProductType> GetAll()
        {
            _context = new();
            return _context.ProductTypes.ToList();
        }
    }
}
