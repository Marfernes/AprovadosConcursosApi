namespace AprovadosConcursosApi.Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}