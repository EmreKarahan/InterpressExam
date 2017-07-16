using System.ServiceModel.Syndication;
using System.Xml;

namespace InterpressExam.Service.Windows.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var aa = GetFeed("http://www.milliyet.com.tr/rss/rssNew/magazinRss.xml");

        }

        public static SyndicationFeed GetFeed(string uri)
        {
            if (string.IsNullOrEmpty(uri)) return null;
            var rssFormatter = new Rss20FeedFormatter(); // for Atom you can use Atom10FeedFormatter()
            var xmlReader = XmlReader.Create(uri);
            rssFormatter.ReadFrom(xmlReader);
            return rssFormatter.Feed;
        }
    }
}
