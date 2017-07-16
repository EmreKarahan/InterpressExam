using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using InterpressExam.Entity;
using InterpressExam.Infrastructure.Parser;
using InterpressExam.Service.Windows.Downloader.ListenSrvRef;

namespace InterpressExam.Service.Windows.Downloader
{
    public class RssParserService
    {
        private readonly RssContext Entities = new RssContext();
        public void Start()
        {
            var files = Entities.RssFile.ToList();

            foreach (RssFile file in files)
            {
                GetFeed(file);
            }
        }

        public void GetFeed(RssFile file)
        {
            var rssFormatter = RssParser.GetFeed(file.AtomLink);


            file.LastUpdateDate = rssFormatter.LastUpdatedTime;
            file.Description = rssFormatter.Description.Text;
            file.Language = rssFormatter.Language;
            file.Title = rssFormatter.Title.Text;


            foreach (SyndicationItem item in rssFormatter.Items)
            {
                RssItem rssItem = new RssItem
                {
                    Title = item.Title.Text,
                    Description = item.Summary.Text,
                    PublishDate = item.PublishDate.DateTime,
                    RssFileId = file.Id,
                    Link = item.Id

                };
                Entities.RssItem.Add(rssItem);
            }

            ListenSrvRef.ListenServiceClient aa = new ListenServiceClient();
            aa.FireDatabaseEvents();
            Entities.SaveChanges();
        }
    }
}