﻿using Proiect.Data;
using Proiect.Models;
using Proiect.Repos.BaseRepo;
using Proiect.Repos.UserRepo;

namespace Proiect.Repos.UserRepo
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(DataContext context) : base(context)
        {
        }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        } 
    }
}
