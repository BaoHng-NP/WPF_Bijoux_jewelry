using Bijoux_Jewelry.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductRepository
    {
        DiamondShopDbContext _context;

        public void Add(Product product)
        {
            _context = new();
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product) {
            _context = new();
            _context.Products.Update(product);
            _context.SaveChanges();

        }
        public Product GetById(int id)
        {
            _context = new();
            return _context.Products.Find(id);

        }
    }
}
