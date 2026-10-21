using System.Collections.Generic;
using System.Data.SqlClient;
using CryptoMarketWeb.DataAccess.Entities;
using Dapper;

namespace CryptoMarketWeb.DataAccess
{
    public class ExpertDbService
    {
        private readonly string _connectionString;
        public ExpertDbService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ExpertContextDB"].ConnectionString;         
        }

        public IEnumerable<Expert> GetCryptoExperts()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Expert>(@"SELECT *
                      FROM Experts
                      WHERE CryptoExpert = 1");
            }
        }

        public IEnumerable<Expert> GetIcoExperts()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Expert>(@"SELECT *
                      FROM Experts
                      WHERE ICOExpert = 1");
            }
        }
    }
}
