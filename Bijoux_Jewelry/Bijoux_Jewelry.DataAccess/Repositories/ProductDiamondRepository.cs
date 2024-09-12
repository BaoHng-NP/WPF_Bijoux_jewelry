using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductDiamondRepository
    {
        DiamondShopDbContext _context;

        public List<ProductDiamond> GetAll()
        {
            _context = new();
            return _context.ProductDiamonds.Include(pd => pd.Diamond).ToList();
        }

        public List<ProductDiamond> GetById(int id)
        {
            _context = new();
            return _context.ProductDiamonds
                           .Include(pd => pd.Diamond)
                               .ThenInclude(d => d.DiamondClarity)
                           .Include(pd => pd.Diamond)
                               .ThenInclude(d => d.DiamondColor)
                           .Include(pd => pd.Diamond)
                               .ThenInclude(d => d.DiamondOrigin)
                           .Where(pd => pd.ProductId == id)
                           .ToList();
        }
        public void delete(ProductDiamond diamond)
        {
            _context = new();
            _context.ProductDiamonds.Remove(diamond);
            _context.SaveChanges();
        }
        public void add(ProductDiamond diamond)
        {
            _context = new();
            _context.ProductDiamonds.Add(diamond);
            _context.SaveChanges();
        }
    }
}
