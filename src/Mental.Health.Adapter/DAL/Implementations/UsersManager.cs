using System.Collections.Generic;
using System.Linq;
namespace Mental.Health.Adapter
{
    public class UsersManager : IUsersManager
    {
        private static List<User> _users;
        public UsersManager()
        {
            try
            {
                _users = JsonFileHandler.ReadFile<User>(KeyStore.FilePaths.Users);
            }
            catch
            {
                _users = new List<User>();
            }
        }
        public bool AddUser(User user)
        {
            if (string.IsNullOrEmpty(user?.UserId))
                return false;
            var existingUser = GetUserById(user.UserId);
            if (existingUser != null)
                return false;
            lock(_users)
                _users.Add(user);
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }
        public bool DeleteUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            lock (_users)
            {
                var user = GetUserById(userId);
                if (user == null)
                    return true;
                _users.Remove(user);
            }
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(string userId) => string.IsNullOrEmpty(userId) ?
                                                                    null
                                                                    : _users.Where(user => string.Equals(userId, user.UserId)).FirstOrDefault();

        public bool UpdateUser(User user)
        {
            if (string.IsNullOrEmpty(user?.UserId))
                return false;
            lock (_users)
            {
                var existingUser = GetUserById(user.UserId);
                if (existingUser != null)
                    return AddUser(user);
                existingUser.UserName = user.UserName;
                existingUser.Gender = user.Gender;
                existingUser.Age = user.Age;
                return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
            }
        }
    }
}
