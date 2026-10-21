using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;
using Dapper;

namespace CryptoMarketAnalysis.DataAccess.DataAccess.DbService
{
    public class IcoDbService
    {
        private readonly string _connectionString;

        public IcoDbService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IcoMarketDB"]
                .ConnectionString;
        }

        public IEnumerable<IcoProject> GetAllIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT *
                      FROM IcoProjects");
            }
        }

        public IEnumerable<IcoProject> GetLiveIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT *
                      FROM IcoProjects
                      WHERE StatusID =2");
            }
        }

        public IEnumerable<IcoLinks> GetIcoLinks()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoLinks>(@"SELECT *
                      FROM IcoLinks");
            }
        }

        public IEnumerable<IcoLinks> GetIcoLinksExcludingEmpty()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoLinks>(@"SELECT *
                      FROM IcoLinks
                      WHERE JsonLinks != '{}'");
            }
        }

        public IEnumerable<IcoProject> GetUpCommingIcos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<IcoProject>(@"SELECT *
                      FROM IcoProjects
                      WHERE StatusID =1");
            }
        }

        public int InitializeStoreProcs()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute(@"
                    IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Upsert_IcoProjectDetails')
                    DROP PROCEDURE Upsert_IcoProjectDetails
                    ");
                conn.Execute(@"
                    CREATE PROCEDURE Upsert_IcoProjectDetails 
	                           @Id uniqueidentifier,
                               @ProjName nvarchar(max),
                               @Description nvarchar(max),
                               @VideoDescriptionUrl nvarchar(max),
                               @About nvarchar(max),
                               @Features nvarchar(max),
                               @TechnicalInfo nvarchar(max),
                               @RoadmapJson nvarchar(max),
                               @LinksJson nvarchar(max),
                               @TeamJson nvarchar(max),
                               @AdvisorsJson nvarchar(max),
                               @CreatedOn datetime,
                               @LastUpdated datetime
                    AS
                    BEGIN
	                    SET NOCOUNT ON;

                        UPDATE [dbo].[IcoProjectDetails]
                       SET 
                           [Description] = @Description,
                           [VideoDescriptionUrl] = @VideoDescriptionUrl,
                           [About] = @About,
                           [Features] = @Features,
                           [TechnicalInfo] = @TechnicalInfo,
                           [RoadmapJson] = @RoadmapJson,
                           [LinksJson] =  @LinksJson, 
                           [TeamJson] = @TeamJson, 
                           [AdvisorsJson] = @AdvisorsJson,
                           [CreatedOn] = @CreatedOn, 
                           [LastUpdated] = @LastUpdated
                       WHERE [ProjName] = @ProjName

                       if @@rowcount = 0
                       BEGIN
		                    INSERT INTO [dbo].[IcoProjectDetails]
				                       ([Id]
				                       ,[ProjName]
				                       ,[Description]
				                       ,[VideoDescriptionUrl]
				                       ,[About]
				                       ,[Features]
				                       ,[TechnicalInfo]
				                       ,[RoadmapJson]
				                       ,[LinksJson]
				                       ,[TeamJson]
				                       ,[AdvisorsJson]
				                       ,[CreatedOn]
				                       ,[LastUpdated])
			                     VALUES
				                       (@Id,
				                       @ProjName, 
				                       @Description, 
				                       @VideoDescriptionUrl,
				                       @About, 
				                       @Features,
				                       @TechnicalInfo, 
				                       @RoadmapJson,
				                       @LinksJson,
				                       @TeamJson, 
				                       @AdvisorsJson,
				                       @CreatedOn, 
				                       @LastUpdated)

                       END


                    END
                    ");

                 conn.Execute(@"
                        IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Upsert_IcoProjects')
                        DROP PROCEDURE Upsert_IcoProjects
                        ");
                return conn.Execute(@"
                        CREATE PROCEDURE Upsert_IcoProjects 
	                          @Id uniqueidentifier,
                              @ProjName nvarchar(max),
                              @ProjImgFileName nvarchar(max),
                              @EventStartDate datetime,
                              @EventEndDate datetime,
                              @Percent float,
                              @IcoHolderRating decimal(18,2),
                              @IcoBazarRating decimal(18,2),
                              @IcoBenchRating decimal(18,2),
                              @CreatedOn datetime,
                              @LastUpdated datetime
                        AS
                        BEGIN
	                        SET NOCOUNT ON;

                            UPDATE [dbo].[IcoProjects]
	                           SET 
		                          [ProjImgFileName] = @ProjImgFileName,
		                          [EventStartDate] = @EventStartDate,
		                          [EventEndDate] = @EventEndDate, 
		                          [Percent] = @Percent,
		                          [IcoHolderRating] = @IcoHolderRating,
		                          [IcoBazarRating] = @IcoBazarRating,
		                          [IcoBenchRating] = @IcoBenchRating, 
		                          [CreatedOn] = @CreatedOn,
		                          [LastUpdated] = @LastUpdated
                           WHERE [ProjName] = @ProjName

                           if @@rowcount = 0
                           BEGIN
		                        INSERT INTO [dbo].[IcoProjects]
                                   ([Id]
                                   ,[ProjName]
                                   ,[ProjImgFileName]
                                   ,[EventStartDate]
                                   ,[EventEndDate]
                                   ,[Percent]
                                   ,[IcoHolderRating]
                                   ,[IcoBazarRating]
                                   ,[IcoBenchRating]
                                   ,[CreatedOn]
                                   ,[LastUpdated])
                             VALUES
                                   (@Id,
		                         @ProjName,
		                         @ProjImgFileName,
		                         @EventStartDate,
		                         @EventEndDate, 
		                         @Percent,
		                         @IcoHolderRating,
		                         @IcoBazarRating,
		                         @IcoBenchRating, 
		                         @CreatedOn,
		                         @LastUpdated)

                           END
                        END
                        ");
            }
        }

        public int Upsert(IcoProject icoProject)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open(); 
                return conn.Execute("Upsert_IcoProjects", new {
                        Id = icoProject.Id,
                        ProjName = icoProject.ProjName,
                        ProjImgFileName = icoProject.ProjImgFileName,
                        EventStartDate = icoProject.EventStartDate,
                        EventEndDate = icoProject.EventEndDate,
                        Percent = icoProject.Percent,
                        IcoHolderRating = icoProject.IcoHolderRating,
                        IcoBazarRating = icoProject.IcoBazarRating,
                        IcoBenchRating = icoProject.IcoBenchRating,
                        CreatedOn = icoProject.CreatedOn,
                        LastUpdated = icoProject.LastUpdated
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int Upsert(IcoProjectDetails icoProjectDetails)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Execute("Upsert_IcoProjectDetails", new {
                        Id = icoProjectDetails.Id,
                        ProjName = icoProjectDetails.ProjName,
                        Description = icoProjectDetails.Description,
                        VideoDescriptionUrl = icoProjectDetails.VideoDescriptionUrl,
                        About = icoProjectDetails.About,
                        Features = icoProjectDetails.Features,
                        TechnicalInfo = icoProjectDetails.TechnicalInfo,
                        RoadmapJson = icoProjectDetails.RoadmapJson,
                        LinksJson = icoProjectDetails.LinksJson,
                        TeamJson = icoProjectDetails.TeamJson,
                        AdvisorsJson = icoProjectDetails.AdvisorsJson,
                        CreatedOn = icoProjectDetails.CreatedOn,
                        LastUpdated = icoProjectDetails.LastUpdated
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}