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
        public List<RssItem> GetAdminPermissionsById(int id)
        {
            return Context.Database.SqlQuery<RssItem>("GetAdminPermissionsById @AdminId", new SqlParameter("AdminId", id)).ToList();
        }

        public RssItem GetAdmin(Expression<Func<RssItem, bool>> predicate)
        {
            return Context.RssItem.FirstOrDefault(predicate);
        }

        public IQueryable<RssItem> GetAdmins(Expression<Func<RssItem, bool>> predicate)
        {
            return Context.RssItem.Where(predicate);
        }
    }
}