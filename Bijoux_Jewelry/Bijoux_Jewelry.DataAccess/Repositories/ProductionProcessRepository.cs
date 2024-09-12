using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class ProductionProcessRepository
    {
        DiamondShopDbContext _context;

        public ProductionProcess GetById(int id)
        {
            _context = new();
            return _context.ProductionProcesses.FirstOrDefault(x => x.OrderId == id);
        }
        public ProductionProcess GetByIdInclude(int id)
        {
            _context = new();
            return _context.ProductionProcesses
               .Include(x => x.ProductionStatus)
               .FirstOrDefault(x => x.OrderId == id);
        }

        public void add(ProductionProcess productionProcess)
        {
            _context = new();

            _context.ProductionProcesses.Add(productionProcess);
            _context.SaveChanges();
        }
        public void update(ProductionProcess productionProcess)
        {
            _context = new();

            _context.ProductionProcesses.Update(productionProcess);
            _context.SaveChanges();
        }
    }
}
