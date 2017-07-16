namespace InterpressExam.Data
{
    public class Repository<T> : RepositoryBase<IDbContextFactory, T>, IRepository<T> where T : class
    {
        public Repository(IDbContextFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}