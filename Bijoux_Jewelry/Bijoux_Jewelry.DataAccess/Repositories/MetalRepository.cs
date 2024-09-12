using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class MetalRepository
    {
        DiamondShopDbContext _context;

        public List<Metal> GetAll()
        {
            _context = new();
            return _context.Metals.ToList();
        }

        public Metal GetById(int id)
        {
            _context = new();
            return _context.Metals.Find(id);
        }

        public void Add(Metal metal)
        {
            _context = new();
            _context.Metals.Add(metal);
            _context.SaveChanges();
        }
        public void Update(Metal metal)
        {
            _context = new();
            _context.Metals.Update(metal);
            _context.SaveChanges();
        }
        
    }
}
