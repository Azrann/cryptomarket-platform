using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AngleSharp;
using CryptoMarketAnalysis.DataAccess.DataAccess.Dtos;
using CryptoMarketAnalysis.DataAccess.DataAccess.Entities;
using Newtonsoft.Json;

namespace IcoReaderService.Reader
{
    public class IcoHolderFileReader
    {
        public async Task<Dictionary<IcoProject, IcoProjectDetails>> GetProjectsDetails(string path)
        {
            Dictionary<IcoProject, IcoProjectDetails> result = new Dictionary<IcoProject, IcoProjectDetails>();

            var icoHolderItems = JsonConvert.DeserializeObject<List<IcoHolderItem>>(File.ReadAllText(path));


            foreach (var icoHolderItem in icoHolderItems)
            {
                icoHolderItem.EventStartDate= CheckMinDateValue(icoHolderItem.EventStartDate);
                icoHolderItem.EventEndDate= CheckMinDateValue(icoHolderItem.EventEndDate);
                
                string filename = "no-image.png";
                if (!string.IsNullOrEmpty(icoHolderItem.ImgUrl))
                {
                    filename = DownloadImage(icoHolderItem.ImgUrl, icoHolderItem.ProjName);
                }

                var projectResult = await ProcessIcoProject(icoHolderItem, filename);

                if (projectResult != null)
                {
                    result.Add(projectResult.Item1, projectResult.Item2);
                }

                Console.WriteLine($"Icoholder: {icoHolderItem.ProjName} {icoHolderItem.Url} {icoHolderItem.ImgUrl}");
            }

            return result;
        }

        private DateTime? CheckMinDateValue(DateTime? date)
        {
            if ((date.HasValue) && (date.Value == DateTime.MinValue))
            {
                return null;
            }

            return date;
        }

        private async Task<Tuple<IcoProject,IcoProjectDetails>> ProcessIcoProject(IcoHolderItem icoHolderItem, string fileName)
        {
            IcoProjectDetails icoProjectDetails = new IcoProjectDetails()
            {
                ProjName = icoHolderItem.ProjName
            };
            IcoProject icoProject = new IcoProject()
            {
                Id = icoProjectDetails.Id,
                ProjImgFileName = fileName,
                ProjName = icoHolderItem.ProjName,
                EventStartDate = icoHolderItem.EventStartDate,
                EventEndDate = icoHolderItem.EventEndDate,
                Percent = icoHolderItem.Percent
            };

            try
            {
                if (icoHolderItem.Url.Contains("/en/"))
                {
                    var url = $"https://icoholder.com{icoHolderItem.Url}";
                    var config = Configuration.Default.WithDefaultLoader();
                    var document = await BrowsingContext.New(config).OpenAsync(url);
                    var cellSelector = ".description-value";
                    var description = document.QuerySelector(cellSelector);

                    icoProjectDetails.ProjName = icoHolderItem.ProjName;
                    icoProjectDetails.Description = description.TextContent;

                    var youtubeSelector = document.QuerySelector("iframe");
                    var youtubeUrl = youtubeSelector != null ? youtubeSelector.GetAttribute("src") : string.Empty;
                    icoProjectDetails.VideoDescriptionUrl = youtubeUrl;

                    var socialLinks = document.QuerySelectorAll(".links .project-links a").Select(x => x.GetAttribute("href"));
                    icoProjectDetails.LinksJson = JsonConvert.SerializeObject(socialLinks);

                    var featuresSelector = document.QuerySelector(".features-value .strip-view-block");
                    var features = featuresSelector != null ? featuresSelector.InnerHtml : string.Empty;
                    icoProjectDetails.Features = features;

                    var aboutSelector = document.QuerySelector(".about-value .strip-view-block");
                    var about = aboutSelector != null ? aboutSelector.InnerHtml : string.Empty;
                    icoProjectDetails.About = about;

                    var techSelector = document.QuerySelector(".tech-value .strip-view-block");
                    var techValue = techSelector != null ? techSelector.InnerHtml : string.Empty;
                    icoProjectDetails.TechnicalInfo = techValue;

                    var milestones = document.QuerySelectorAll(".milestone-item");
                    var milestoneDictionary = new Dictionary<string, string>();
                    foreach (var milestone in milestones)
                    {
                        var milestoneName = milestone.QuerySelector(".milestone-name-text").InnerHtml;
                        var milestoneText = milestone.QuerySelector(".milestone-text").InnerHtml;
                        if (!milestoneDictionary.ContainsKey(milestoneName))
                        {
                            milestoneDictionary.Add(milestoneName, milestoneText);
                        }
                    }

                    icoProjectDetails.RoadmapJson = JsonConvert.SerializeObject(milestoneDictionary);

                    var teamMembers = document.QuerySelectorAll("#team .members-row .col-lg-4.col-sm-6.text-center.mb-4");
                    var teamDictionary = new Dictionary<string, TeamMember>();
                    if (teamMembers != null)
                    {
                        foreach (var teamMember in teamMembers)
                        {
                            var imageUrl = GetImageUrl(teamMember.QuerySelector(".member-icon").GetAttribute("style"));
                            var titleSelector = teamMember.QuerySelector(".member-title a");
                            if (titleSelector == null)
                            {
                                titleSelector = teamMember.QuerySelector(".member-title");
                            }
                            var name = titleSelector.InnerHtml;
                            
                            var position = teamMember.QuerySelector(".member-position").InnerHtml;
                            var linkedInUrl = titleSelector.GetAttribute("href");
                            var pictureFileName = DownloadImage(imageUrl, $"{icoHolderItem.ProjName}{name}".Replace(" ", "_"));
                            TeamMember member = new TeamMember()
                            {
                                Id = Guid.NewGuid(),
                                Name = name,
                                PictureUrl = imageUrl,
                                LinkedInUrl = linkedInUrl,
                                Position = position,
                                PictureFileName = pictureFileName
                            };
                            teamDictionary.Add(name, member);
                        }

                        icoProjectDetails.TeamJson = JsonConvert.SerializeObject(teamDictionary);
                    }

                    var teamAdvisors = document.QuerySelectorAll("#team .advisers-row .col-lg-4.col-sm-6.text-center.mb-4");
                    if (teamAdvisors != null)
                    {
                        teamDictionary = new Dictionary<string, TeamMember>();
                        foreach (var teamMember in teamAdvisors)
                        {
                            var imageUrl = GetImageUrl(teamMember.QuerySelector(".member-icon").GetAttribute("style"));
                            var titleSelector = teamMember.QuerySelector(".member-title a");
                            if (titleSelector == null)
                            {
                                titleSelector = teamMember.QuerySelector(".member-title");
                            }
                            var name = titleSelector.InnerHtml;
                            var position = teamMember.QuerySelector(".member-position").InnerHtml;
                            var linkedInUrl = titleSelector.GetAttribute("href");
                            var pictureFileName = DownloadImage(imageUrl, $"{icoHolderItem.ProjName}{name}".Replace(" ", "_"));

                            TeamMember member = new TeamMember()
                            {
                                Id = Guid.NewGuid(),
                                Name = name,
                                PictureUrl = imageUrl,
                                LinkedInUrl = linkedInUrl,
                                Position = position,
                                PictureFileName = pictureFileName
                            };
                            teamDictionary.Add(name, member);
                        }

                        icoProjectDetails.AdvisorsJson = JsonConvert.SerializeObject(teamDictionary);
                    }

                    var icoHolderRatingSelector = document.QuerySelector("#animate-rating");
                    icoProject.IcoHolderRating = icoHolderRatingSelector != null
                        ? decimal.Parse(icoHolderRatingSelector.GetAttribute("content"))
                        : 0;

                    var icoBazarRatingSelector = document.QuerySelector(".icobazaar-rating");
                    icoProject.IcoBazarRating = icoBazarRatingSelector != null
                        ? decimal.Parse(icoBazarRatingSelector.InnerHtml)
                        : 0;

                    var icoBenchRatingSelector = document.QuerySelector(".icobench-rating");
                    icoProject.IcoBenchRating = icoBenchRatingSelector != null
                        ? decimal.Parse(icoBenchRatingSelector.InnerHtml)
                        : 0;
                }else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return new Tuple<IcoProject, IcoProjectDetails>(icoProject, icoProjectDetails);
        }

        private string GetImageUrl(string style)
        {
            return style.Replace("background: url('", "").Replace("');", "");
        }

        private string DownloadImage(string imgUrl, string projName)
        {
            try
            {
                if (imgUrl.Contains("data:image"))
                {
                    return imgUrl;
                }

                if (imgUrl.Contains("no-image.png"))
                {
                    return "no-image.png";
                }

                if (imgUrl.StartsWith("/"))
                {
                    imgUrl = "https://icoholder.com/" + imgUrl;
                }

                string fileExtension = "";

                if (imgUrl.EndsWith(".png"))
                {
                    fileExtension = "png";
                }

                if (imgUrl.EndsWith(".jpg"))
                {
                    fileExtension = "jpg";
                }

                if (imgUrl.EndsWith(".jpeg"))
                {
                    fileExtension = "jpeg";
                }

                if (string.IsNullOrEmpty(fileExtension))
                {
                    return DownloadImageWithoutExtension(imgUrl, projName);
                }

                var fileName = $"{projName.Replace(" ", "_")}.{fileExtension}";
                var savePath =
                    $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/img/{fileName}";

                if (!File.Exists(savePath))
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(imgUrl,
                            savePath);
                    }
                }

                return fileName;
            }
            catch (Exception ex)
            {
                return "no-image.png";
            }
        }

        private string DownloadImageWithoutExtension(string imgUrl, string projName)
        {
            var fileName = $"{projName.Replace(" ", "_")}.png";
            var savePath = $"{System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/img/{fileName}";

            if (!File.Exists(savePath))
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(imgUrl);
                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        using (var yourImage = System.Drawing.Image.FromStream(mem))
                        {
                            yourImage.Save(savePath,ImageFormat.Png);
                        }
                    }
                }
            }
            return fileName;
        }
    }
}