using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using InterpressExam.Entity;

namespace InterpressExam.Service.Windows.Downloader
{
    class Program
    {
        private static readonly RssContext Entities = new RssContext();
        static void Main(string[] args)
        {
           
            var files = Entities.RssFile.ToList();

            foreach (RssFile file in files)
            {
                var aa = GetFeed(file);
            }
        }

        public static SyndicationFeed GetFeed(RssFile file)
        {
            if (string.IsNullOrEmpty(file.AtomLink)) return null;
            var rssFormatter = new Rss20FeedFormatter(); // for Atom you can use Atom10FeedFormatter()
            var xmlReader = XmlReader.Create(file.AtomLink);
            rssFormatter.ReadFrom(xmlReader);

            file.LastUpdateDate = rssFormatter.Feed.LastUpdatedTime;
            file.Description = rssFormatter.Feed.Description.Text;
            file.Language = rssFormatter.Feed.Language;
            file.Title = rssFormatter.Feed.Title.Text;
            

            Entities.SaveChanges();

            return rssFormatter.Feed;
        }
    }
}
