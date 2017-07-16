using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using InterpressExam.Entity;

namespace InterpressExam.Service.Windows.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            RssContext entities = new RssContext();
            var files = entities.RssFile.ToList();

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
            return rssFormatter.Feed;
        }
    }
}
