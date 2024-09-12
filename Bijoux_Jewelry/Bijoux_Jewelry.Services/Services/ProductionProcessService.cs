using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class ProductionProcessService
    {
        ProductionProcessRepository _repo =new();
        public void getProductionProcessById(int id)
        {
            _repo.GetById(id);
        }

        public ProductionProcess getProductionProcessesByOrder(int id)
        {
            return _repo.GetById(id);
        }
        public void addProductionProcess(ProductionProcess productionProcess)
        {
            _repo.add(productionProcess);
        }
        public void updateProductionProcess(ProductionProcess productionProcess)
        {
            _repo.update(productionProcess);
        }

        public ProductionProcess getProductionProcessesByOrderInclude(int id)
        {
            return _repo.GetByIdInclude(id);
        }
    }
}
