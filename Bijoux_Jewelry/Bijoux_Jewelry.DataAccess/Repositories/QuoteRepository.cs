using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class QuoteRepository
    {
        private DiamondShopDbContext _context;

        public List<Quote> GetAll()
        {
            _context = new();
            return _context.Quotes
                .Include(q => q.Account)
                .Include(q => q.DesignStaff)
                .Include(q => q.Product)
                .Include(q => q.ProductionStaff)
                .Include(q => q.QuoteStatus)
                .ToList();
        }
        public Quote GetById(int id)
        {
            _context = new();
            return _context.Quotes
                           .Include(q => q.Account)
                           .Include(q => q.DesignStaff)
                           .Include(q => q.Product)
                           .Include(q => q.ProductionStaff)
                           .Include(q => q.QuoteStatus)
                           .SingleOrDefault(q => q.Id == id);
        }
        public Quote GetByIdUpdate(int id)
        {
            _context = new();
            return _context.Quotes.Find(id);
        }
        public void Add(Quote quote)
        {
            _context = new();
            _context.Quotes.Add(quote);
            _context.SaveChanges();

        }

        public void Update(Quote quote)
        {
            _context = new();
            _context.Quotes.Update(quote);
            _context.SaveChanges();

        }

        
    }
}
