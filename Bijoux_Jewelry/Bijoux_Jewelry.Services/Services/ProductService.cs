using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class ProductService
    {
        private ProductRepository _repository=new();

        public Product CreateProduct(Product product)
        {
            _repository.Add(product);
            return product;
        }
        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }
        public void updateProduct(Product product)
        {
            _repository.Update(product);
        }
    }
}
