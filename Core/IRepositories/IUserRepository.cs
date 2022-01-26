using ProjectAPI.Models;
using System.Collections.Generic;

namespace ProjectAPI.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool UserExists(int id);
        List<User> Admins();

    }
}