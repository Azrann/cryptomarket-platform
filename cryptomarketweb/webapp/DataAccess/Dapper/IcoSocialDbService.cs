using System.Collections.Generic;
using System.Data.SqlClient;
using CryptoMarketWeb.DataAccess.Entities;
using Dapper;

namespace CryptoMarketWeb.DataAccess
{
    public class IcoSocialDbService
    {
        private readonly string _connectionString;
        public IcoSocialDbService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IcoSocialDB"].ConnectionString;         
        }

        public IEnumerable<IcoSocialImpact> GetIcoSocialImpacts()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoSocialImpact>(@"SELECT * FROM IcoSocialImpacts
                    WHERE LastUpdated > convert(char(14),DATEADD(HOUR, -1, GETUTCDATE()),121)+'00:00'
                    Order by LastUpdated desc");
            }
        }
    }
}
