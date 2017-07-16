
namespace InterpressExam.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        T GetById(object id);
    }


    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>();
    }
}
