using System.ServiceModel.Syndication;
using System.Xml;

namespace InterpressExam.Infrastructure.Parser
{
    public class RssParser
    {
        public static SyndicationFeed GetFeed(string uri)
        {
            if (string.IsNullOrEmpty(uri)) return null;
            var rssFormatter = new Rss20FeedFormatter();
            var xmlReader = XmlReader.Create(uri);
            rssFormatter.ReadFrom(xmlReader);
            return rssFormatter.Feed;
        }

    }
}