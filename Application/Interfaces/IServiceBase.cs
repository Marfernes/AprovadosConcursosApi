namespace AprovadosConcursosApi.Application.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        List<T> GetAll();
        T? GetById(Guid id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}