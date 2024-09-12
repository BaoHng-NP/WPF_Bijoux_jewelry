using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.DataAccess.Models
{
    public class ProductionStatusService
    {
        ProductionStatusRepository _productionStatusRepository = new();

        public List<ProductionStatus> getAll()
        {
            return _productionStatusRepository.getAll();
        }
    }
}
