using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class AccountService
    {
        private AccountRepository _accountRepository = new();

        public Account? Authenticate(String username, String password)
        {
            return _accountRepository.getOne(username, password);

        }
        public Account GetbyId(int id)
        {
            return _accountRepository.GetById(id);
        }
        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }

        public List<Account> GetDesignStaff() {
            List<Account> designstaffs= _accountRepository.GetAll().Where(x=>x.Role==4).ToList();
            return designstaffs;
        }
        public List<Account> GetProductionStaff()
        {
            List<Account> productionstaffs = _accountRepository.GetAll().Where(x => x.Role == 5).ToList();
            return productionstaffs;
        }
        public List<Account> GetStaff()
        {
            List<int> roles = new List<int> { 3, 4, 5 };
            List<Account> staffs = _accountRepository.GetAll().Where(x => roles.Contains(x.Role)).ToList();
            return staffs;
        }
        public List<Account> GetCustomer()
        {
            List<Account> customer = _accountRepository.GetAll().Where(x => x.Role == 1).ToList();
            return customer;
        }
    }
}
