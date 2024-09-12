using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class MetalService
    {
        MetalRepository _metalRepository =new();

        public List<Metal> GetAll()
        {
            return _metalRepository.GetAll();
        }

        public Metal GetById(int id)
        {
            return _metalRepository.GetById(id);
        }

        public void Add(Metal metal)
        {
            _metalRepository.Add(metal);
        }

        public void Update(Metal metal)
        {
            _metalRepository.Update(metal);
        }

    }
}
