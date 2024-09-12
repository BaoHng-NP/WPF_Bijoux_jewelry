using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductMetalRepository
    {
        DiamondShopDbContext _context;
    public List<ProductMetal> GetAll()
        {
            _context = new();
            return _context.ProductMetals.Include(pm => pm.Metal).ToList();
        }
        public List<ProductMetal> GetById(int id)
        {
            _context = new();
            return _context.ProductMetals.Include(pm => pm.Metal)
                            .Where(pm => pm.ProductId == id)
                            .ToList(); 
        }
        public void delete(ProductMetal metal)
        {
            _context = new();
            _context.ProductMetals.Remove(metal);
            _context.SaveChanges();
        }
        public void add(ProductMetal metal)
        {
            _context = new();
            _context.ProductMetals.Add(metal);
            _context.SaveChanges();
        }
    }
}
