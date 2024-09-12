using Bijoux_Jewelry.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Repositories
{
    public class DiamondRepository
    {
        DiamondShopDbContext _context;
        public List<Diamond> GetAll()
        {
            _context = new();
            List<Diamond> list= _context.Diamonds
                .Include(d => d.DiamondClarity)
                .Include(d => d.DiamondColor)
                .Include(d => d.DiamondOrigin)
                .ToList();
            return list;
        }

        public Diamond GetById(int id)
        {
            _context = new();
            return _context.Diamonds.Find(id);
        }

        public void Add(Diamond diamond)
        {
            _context = new();
            _context.Diamonds.Add(diamond);
            _context.SaveChanges();
        }

         public void Update(Diamond diamond)
        {
            _context = new();
            _context.Diamonds.Update(diamond);
            _context.SaveChanges();
        }

        public void delete(Diamond diamond)
        {
            _context = new();
            _context.Diamonds.Remove(diamond);
            _context.SaveChanges();
        }
        public List<DiamondColor> GetAllColor()
        {
            _context = new();
            List<DiamondColor> list = _context.DiamondColors.ToList();
            return list;
        }
        public List<DiamondOrigin> GetAllOrigin()
        {
            _context = new();
            List<DiamondOrigin> list = _context.DiamondOrigins.ToList();
            return list;
        }
        public List<DiamondClarity> GetAllClarity()
        {
            _context = new();
            List<DiamondClarity> list = _context.DiamondClarities.ToList();
            return list;
        }

    }
}
