using Bijoux_Jewelry.DataAccess.Models;
using Bijoux_Jewelry.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bijoux_Jewelry.BusinessLogicLayer.Services
{
    public class QuoteService
    {
        private QuoteRepository _repo = new();
        private ProductService _productService = new ProductService();

        public void CreateQuote(Quote quote)
        {
            Product product = new();
            _repo.Add(quote);
        }

        public List<Quote> GetAllQuote()
        {
            return _repo.GetAll();
        }
        public List<Quote> GetAllQuoteCustomer(int accountId)
        {
            return _repo.GetAll().Where(x=>x.AccountId ==accountId).ToList();
        }


        public Quote GetQuoteById(int id)
        {
            return _repo.GetById(id);
        }
        public Quote GetQuoteByIdUpdate(int id)
        {
            return _repo.GetByIdUpdate(id);
        }
        public void UpdateQuote(Quote quote)
        {
             Quote newq = quote;
            _repo.Update(quote);

        }
    }
}
