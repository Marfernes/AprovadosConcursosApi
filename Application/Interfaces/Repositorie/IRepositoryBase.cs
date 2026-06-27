namespace AprovadosConcursosApi.Application.Interfaces.Repositorie
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}