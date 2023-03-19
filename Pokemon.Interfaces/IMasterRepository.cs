using Pokemon.Domain.Masters;

using System.Threading.Tasks;

namespace Pokemon.Interfaces
{
    public interface IMasterRepository
    {
        Task<Master> AddOrUpdate(Master master);
        Task<Master> GetByEmail(string email);
        Task<Master> GetById(int id);
        Task<Master> GetByUserName(string userName);
        Task Remove(Master master);
        Task RemoveById(int id);
    }
}