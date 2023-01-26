using Proiect.Models;
using Proiect.Repos.BaseRepo;

namespace Proiect.Repos.UserRepo
{
    public interface IOrderContainsRepo : IBaseRepo<User>
    {
        public User FindByEmail(string email);
    }
}
