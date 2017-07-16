using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using InterpressExam.Data.Contract;
using InterpressExam.Entity;

namespace InterpressExam.Data.Impl
{
    public class RssItemRepository : BaseRepository, IRssItemRepository
    {
        public void EmptyTable()
        {
            Context.Database.ExecuteSqlCommand("TRUNCATE TABLE [RssItem]");
        }

        public void AddRssItem(RssItem rssItem)
        {
            Context.RssItem.Add(rssItem);
            Context.SaveChanges();
        }

        public IEnumerable<RssFile> RssFileGetList()
        {
            return Context.RssFile.ToList();
        }

        public IEnumerable<RssItem> RssItemGetList()
        {
            return Context.RssItem.ToList();
        }
    }
}