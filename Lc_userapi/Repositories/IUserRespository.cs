using Lc_userapi.Models;

namespace Lc_userapi.Repositories
{
    public interface IUserRespository
    {

        Task<userClass> GetbyIdAsync(int id);

        Task<IEnumerable<userClass>> GetallAsync();

        Task AddAsync(userClass Uc);

        Task UpdateAsync(userClass Uc);
        Task DeleteAsync(int id);
    }
}
