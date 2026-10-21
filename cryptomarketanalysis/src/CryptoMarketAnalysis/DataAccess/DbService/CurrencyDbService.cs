using System;
using System.Collections.Generic;
using CryptoMarketAnalysis.DataAccess.Entities;

namespace CryptoMarketAnalysis.DataAccess
{
    public class CurrencyDbService
    {
        private IRepository<CurrencyInfo> _currencyRepo;
        private IRepository<Suggestion> _suggestionRepo;

        public CurrencyDbService()
        {
            var currencyContext = new CurrencyContext();
            _currencyRepo = new Repository<CurrencyInfo>(currencyContext);
            _suggestionRepo = new Repository<Suggestion>(currencyContext);
        }
        
        public void AddCurrency(CurrencyInfo currencyInfo)
        {
            var result = _currencyRepo.Add(currencyInfo);
            _currencyRepo.Save();
        }

        public IEnumerable<CurrencyInfo> GetById(Guid id)
        {
            return _currencyRepo.GetAll(x => x.Id == id);
        }
    }
}
