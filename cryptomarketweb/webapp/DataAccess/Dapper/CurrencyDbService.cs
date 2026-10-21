using System.Collections.Generic;
using System.Data.SqlClient;
using CryptoMarketWeb.DataAccess.Entities;
using Dapper;

namespace CryptoMarketWeb.DataAccess.Dapper
{
    public class CurrencyDbService
    {
        private readonly string _connectionString;
        public CurrencyDbService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CurrencyContextDB"].ConnectionString;         
        }

        public IEnumerable<CurrencyInfo> GetCurrencies()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<CurrencyInfo>(@"SELECT TOP 100 [Id]
                  ,[currencyId]
                  ,[name]
                  ,[symbol]
                  ,[rank]
                  ,[price_usd]
                  ,[price_btc]
                  ,[last24h_volume_usd]
                  ,[market_cap_usd]
                  ,[available_supply]
                  ,[total_supply]
                  ,[percent_change_1h]
                  ,[percent_change_24h]
                  ,[percent_change_7d]
                  ,[last_updated]
                  ,[CreatedOn]
                  ,[LastUpdated]
              FROM[cur1].[dbo].[CurrencyInfoes]
              Order by[LastUpdated] desc");
            }
        }

        public CurrencyInfo GetCrytpocurrency(string name)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.QueryFirst<CurrencyInfo>(@"SELECT TOP 1 [Id]
                  ,[currencyId]
                  ,[name]
                  ,[symbol]
                  ,[rank]
                  ,[price_usd]
                  ,[price_btc]
                  ,[last24h_volume_usd]
                  ,[market_cap_usd]
                  ,[available_supply]
                  ,[total_supply]
                  ,[percent_change_1h]
                  ,[percent_change_24h]
                  ,[percent_change_7d]
                  ,[last_updated]
                  ,[CreatedOn]
                  ,[LastUpdated]
              FROM[cur1].[dbo].[CurrencyInfoes]
              WHERE name = @Name
              Order by[LastUpdated] desc",
                    new { Name = name.Replace("__",".").Replace("_"," ") });
            }
        }

        public IEnumerable<CurrencyNumbers> GetPricesLastHour()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<CurrencyNumbers>(@"SELECT distinct
                    [symbol],
		            (
		            SELECT  CAST(price_usd AS nvarchar(15))+','
                    FROM [cur1].[dbo].[CurrencyInfoes] t2
                    WHERE t2.[symbol] = t1.[symbol] AND CreatedOn > DATEADD(HOUR, -1, GETUTCDATE())
		            ORDER BY CreatedOn 
                    FOR XML PATH('')) as Numbers
              FROM [cur1].[dbo].[CurrencyInfoes] t1
              WHERE CreatedOn > DATEADD(HOUR, -1, GETUTCDATE())");
            }
        }

        public IEnumerable<MarketCapItem> GetMarketCapLastHour()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<MarketCapItem>(@"SELECT 
              [symbol] as Symbol,
	          Market_cap_usd as MarketCap,
	          right ('00'+ltrim(str( DATEPART(HOUR, CreatedOn))),2 )
	          as 'Hour',

                    right('00' + ltrim(str(DATEPART(MINUTE, CreatedOn))), 2) as ""Minute""
                    FROM[cur1].[dbo].[CurrencyInfoes] t1
                        WHERE CreatedOn > DATEADD(HOUR, -1, GETUTCDATE()) And ""Rank"" < 6
                    ORDER BY CreatedOn");
            }
        }

 
            public IEnumerable<CurrencyNumbers> GetPricesLast24Hour()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<CurrencyNumbers>(@"SELECT distinct
                    [symbol],
		            (
		            SELECT  CAST(price_usd AS nvarchar(15))+','
                    FROM [cur1].[dbo].[CurrencyInfoes] t2
                    WHERE t2.[symbol] = t1.[symbol] AND CreatedOn > DATEADD(DAY, -1, GETUTCDATE())
		            ORDER BY CreatedOn 
                    FOR XML PATH('')) as Numbers
              FROM [cur1].[dbo].[CurrencyInfoes] t1
              WHERE CreatedOn > DATEADD(DAY, -1, GETUTCDATE())");
            }
        }


        public IEnumerable<MarketCapItem> GetMarketCapLast24Hour()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<MarketCapItem>(@"SELECT 
              [symbol] as Symbol,
	          Market_cap_usd as MarketCap,
	          right ('00'+ltrim(str( DATEPART(HOUR, CreatedOn))),2 )
	          as 'Hour',

                    right('00' + ltrim(str(DATEPART(MINUTE, CreatedOn))), 2) as ""Minute""
                    FROM[cur1].[dbo].[CurrencyInfoes] t1
                        WHERE CreatedOn > DATEADD(DAY, -1, GETUTCDATE()) And ""Rank"" < 6
                    ORDER BY CreatedOn");
            }
        }
    }
}
