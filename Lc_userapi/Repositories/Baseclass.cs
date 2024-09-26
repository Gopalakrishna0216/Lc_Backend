namespace Lc_userapi.Repositories
{
    public abstract class Baseclass<T> where T : class
    {
        protected readonly string _connectionstring;
        protected Baseclass(string connectionstring) 
        { 
          _connectionstring = connectionstring;
        
        }

        public abstract Task<T> GetbyIdAsync(int id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task AddAsync(T entity);

        public abstract Task DeleteAsync(int id);

        public abstract Task UpdateAsync(T entity);




    }
}
