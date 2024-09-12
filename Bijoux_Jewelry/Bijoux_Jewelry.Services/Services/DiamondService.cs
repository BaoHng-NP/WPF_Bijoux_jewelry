using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class DiamondService
    {
        DiamondRepository _diamondRepository = new();

        public List<Diamond> GetAll()
        {
            return _diamondRepository.GetAll();
        }
        public Diamond GetById(int id)
        {
            return _diamondRepository.GetById(id);
        }
        public void add(Diamond diamond)
        {
            _diamondRepository.Add(diamond);
        }
        public void update(Diamond diamond)
        {
            _diamondRepository.Update(diamond);
        }
        public List<DiamondColor> GetAllColor()
        {
            return _diamondRepository.GetAllColor();
        }
        public List<DiamondOrigin> GetAllOrigin()
        {
            return _diamondRepository.GetAllOrigin();
        }
        public List<DiamondClarity> GetAllClarity()
        {
            return _diamondRepository.GetAllClarity();
        }
    }
}
