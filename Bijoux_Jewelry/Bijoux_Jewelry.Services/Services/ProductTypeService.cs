using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class ProductTypeService
    {
        private ProductTypeRepository _repository =new();

        public List<ProductType> GetAllProductType()
        {
            return _repository.GetAll();
        }
    }
}
