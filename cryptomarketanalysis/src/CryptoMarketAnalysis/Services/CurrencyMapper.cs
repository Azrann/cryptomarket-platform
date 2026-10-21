using System.Collections.Generic;

namespace CryptoMarketAnalysis.Services
{
    public class CurrencyMapper
    {
        private static Dictionary<string, string> currenciesMap;
        private HttpClientHelper client;

        public CurrencyMapper()
        {
            currenciesMap = new Dictionary<string, string>();
            client = new HttpClientHelper();
        }

        public Dictionary<string, string> CurrenciesMap
        {
            get {
                if (currenciesMap == null || currenciesMap.Count < 1)
                {
                    foreach (var currency in client.GetCurrencies())
                    {
                        currenciesMap.Add(currency.name.ToUpper(), currency.symbol.ToUpper());
                        if (!currenciesMap.ContainsKey(currency.symbol.ToUpper()))
                        {
                            currenciesMap.Add(currency.symbol.ToUpper(), currency.symbol.ToUpper());
                        }
                    }
                }
                return currenciesMap;
            }
        }
    }
}
