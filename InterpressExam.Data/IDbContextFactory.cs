using System;
using System.Data.Entity;

namespace InterpressExam.Data
{
    public interface IDbContextFactory : IDisposable
    {
        //there is only one database, initially returned default
        DbContext Get();
    }
}