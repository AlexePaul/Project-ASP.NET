using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.UserRepo
{
    public interface IUserRepo : IBaseRepo<User>
    {
        public User FindByEmail(string email);

        public Task<List<User>> GetAllUsersWithOrders();
    }
}
