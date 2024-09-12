using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class OrderRepository
    {
        DiamondShopDbContext   _context ;

        public List<Order> GetAllInclude()
        {
            _context = new();
            return _context.Orders
                .Include(o => o.Account)
                .Include(o => o.DesignStaff)
                .Include(o => o.OrderStatus)
                .Include(o => o.Product)
                .Include(o => o.ProductionProcesses)
                .Include(o => o.ProductionStaff)
                .ToList();
        }

        public List<Order> GetAll()
        {
            _context = new();
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            _context = new();
            return _context.Orders.Find(id);
        }
        public Order GetByIdInclude(int id)
        {
            _context = new();
            return _context.Orders
                .Include(o => o.Account)
                .Include(o => o.DesignStaff)
                .Include(o => o.OrderStatus)
                .Include(o => o.Product)
                .Include(o => o.ProductionProcesses)
                .Include(o => o.ProductionStaff)
                .SingleOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            _context = new();
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void delete(Order order)
        {
            _context = new();
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context = new();
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

    }
}
