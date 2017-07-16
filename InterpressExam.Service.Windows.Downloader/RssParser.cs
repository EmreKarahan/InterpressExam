using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using InterpressExam.Entity;
using InterpressExam.Service.Windows.Downloader.ListenSrvRef;

namespace InterpressExam.Service.Windows.Downloader
{
    public class RssParser
    {
        private  readonly RssContext Entities = new RssContext();
        public void Start()
        {
            var files = Entities.RssFile.ToList();

            foreach (RssFile file in files)
            {
                var aa = GetFeed(file);
            }
        }

        public SyndicationFeed GetFeed(RssFile file)
        {
            if (string.IsNullOrEmpty(file.AtomLink)) return null;
            var rssFormatter = new Rss20FeedFormatter(); // for Atom you can use Atom10FeedFormatter()
            var xmlReader = XmlReader.Create(file.AtomLink);
            rssFormatter.ReadFrom(xmlReader);

            file.LastUpdateDate = rssFormatter.Feed.LastUpdatedTime;
            file.Description = rssFormatter.Feed.Description.Text;
            file.Language = rssFormatter.Feed.Language;
            file.Title = rssFormatter.Feed.Title.Text;


            foreach (SyndicationItem item in rssFormatter.Feed.Items)
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
            return rssFormatter.Feed;
        }
    }
}