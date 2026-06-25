namespace AprovadosConcursosApi.Application.Interfaces.Repositorie
{
    public interface IRepositoryBase<T> where T : class
    {
        T? GetById(Guid id);
        List<T> GetAll();

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void SaveChanges();
    }
}