using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class ProductDiamondService
    {
        ProductDiamondRepository _repo= new();
        public List<ProductDiamond> GetAll()
        {
            return _repo.GetAll();
        }
        public List<ProductDiamond> GetbyId(int id)
        {
            return _repo.GetById(id);
        }
        public void DeleteDiamond(ProductDiamond diamond)
        {
            _repo.delete(diamond);
        }
        public double getDiamondPrice(int id)
        {
            List<ProductDiamond> list = GetAll();
            double sum = 0;
            foreach (var item in list)
            {
                if (item.Id == id)
                {
                    sum += item.Price;
                }
            }
            return sum;
        }
        public void AddDiamond(ProductDiamond diamond)
        {
            _repo.add(diamond);
        }
    }
}
