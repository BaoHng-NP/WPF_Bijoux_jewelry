using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class ProductMetalService
    {
        ProductMetalRepository _repo = new();
        public List<ProductMetal> GetAll()
        {
            return _repo.GetAll();
        }
        public List<ProductMetal> GetByProductId(int id)
        {
            return _repo.GetById(id);
        }
        public void deleteProductMetal(ProductMetal metal)
        {
            _repo.delete(metal);
        }   
        public double getMetalPrice(int id)
        {
            List<ProductMetal> list = GetAll();
            double sum = 0;
            foreach (var item in list)
            {
                if (item.Id == id)
                {
                    sum+=item.Price;
                }
            }
            return sum;
        }
        public void addProductMetal(ProductMetal metal)
        {
            _repo.add(metal);
        }

    }
}
