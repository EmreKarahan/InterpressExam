using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InterpressExam.Entity;

namespace InterpressExam.Data.Contract
{
    public interface IRssItemRepository
    {
        List<RssItem> GetAdminPermissionsById(int id);

        RssItem GetAdmin(Expression<Func<RssItem, bool>> predicate);

        IQueryable<RssItem> GetAdmins(Expression<Func<RssItem, bool>> predicate);
    }
}