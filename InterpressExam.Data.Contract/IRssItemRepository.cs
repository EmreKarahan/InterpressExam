using System.Collections.Generic;
using InterpressExam.Entity;

namespace InterpressExam.Data.Contract
{
    public interface IRssItemRepository
    {
        void EmptyTable();

        void AddRssItem(RssItem rssItem);
        IEnumerable<RssFile> RssFileGetList();

        IEnumerable<RssItem> RssItemGetList();
    }
}