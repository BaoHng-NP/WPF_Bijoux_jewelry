using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class OrderService
    {
        OrderRepository _orderRepository = new();
        public List<Order> GetAllOrder()
        {
            return _orderRepository.GetAll();
        }
        public List<Order> GetAllOrderInclude()
        {
            return _orderRepository.GetAllInclude();
        }

        public List<Order> GetCustomerOrder(int id)
        {
            return _orderRepository.GetAllInclude().Where(x => x.AccountId == id).ToList();
        }

        public List<Order> GetAssignedDesign(int id)
        {
            return _orderRepository.GetAllInclude().Where(x => x.DesignStaffId == id).ToList();
        }

        public List<Order> GetAssignedProduction(int id)
        {
            return _orderRepository.GetAllInclude().Where(x => x.ProductionStaffId == id).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
        public Order GetOrderByIdInclude(int id)
        {
            return _orderRepository.GetByIdInclude(id);
        }
        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }
        public void DeleteOrder(Order order)
        {
            _orderRepository.delete(order);
        }
        public void updateOrder(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
