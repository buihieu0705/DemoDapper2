namespace DemoDapper.Repository
{
    public interface IGenericRepository<TResponse, TRequest, Key>
    {
        Task<IEnumerable<TResponse>> GetAll();
        Task<TResponse> GetById(Key id);

        Task<TResponse> Create(TRequest name);

        Task Update(Key id, TRequest value);

        Task Delete(Key id);

    }
}
