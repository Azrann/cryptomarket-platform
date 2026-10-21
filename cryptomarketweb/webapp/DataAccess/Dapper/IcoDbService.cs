using System.Collections.Generic;
using System.Data.SqlClient;
using CryptoMarketWeb.DataAccess.Entities;
using CryptoMarketWeb.Services;
using Dapper;

namespace CryptoMarketWeb.DataAccess
{
    public class IcoDbService
    {
        private readonly string _connectionString;
        public IcoDbService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IcoDB"].ConnectionString;         
        }

        public IEnumerable<IcoProject> GetIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT * FROM IcoProjects");
            }
        }

        public IEnumerable<IcoProject> GetLiveIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT * FROM IcoProjects
                        WHERE EventStartDate < GETUTCDATE() AND EventEndDate > GetUtcDate()");
            }
        }

        public IEnumerable<IcoProject> GetUpcommingIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT * FROM IcoProjects
                        WHERE (EventStartDate is null) OR (EventStartDate > GETUTCDATE())");
            }
        }

        public IcoProject GetIcoByProjectName(string projName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<IcoProject>("SELECT * FROM IcoProjects WHERE ProjName = @ProjName",
                    new { ProjName = projName });
            }
        }

        public IcoProjectDetails GetICoDetailByProjectName(string projName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.QueryFirstOrDefault<IcoProjectDetails>(@"SELECT * FROM IcoProjectDetails WHERE ProjName = @ProjName",
                    new { ProjName = projName});
            }
        }
    }
}
