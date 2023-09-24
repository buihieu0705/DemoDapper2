using DemoDapper.Context;

namespace DemoDapper.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly DapperContext db;

        public BaseRepository(DapperContext db)
        {
            this.db = db;
        }

        public async Task<T> Create(T entity)
        {
        }

        public async Task Delete(int id)
        {
        }

        public async Task<IEnumerable<T>> GetAll()
        {
        }

        public async Task<T> GetById(int id)
        {
        }

        public async Task Update(int id, T entity)
        {
        }
    }
}
