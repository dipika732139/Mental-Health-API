using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Adapter
{
    public interface IUsersManager
    {
        List<User> GetAllUsers();
        User GetUserById(string userId);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUserById(string userId);

    }
}
