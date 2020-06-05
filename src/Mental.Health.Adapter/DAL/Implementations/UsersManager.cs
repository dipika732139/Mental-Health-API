using Mental.Health.Adapter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mental.Health.Adapter
{
    public class UsersManager : IUsersManager
    {
        private static List<User> _users;
        private PincodeValidator pinvalidator;
        private static Dictionary<string, int> NameCountMap = new Dictionary<string, int>();
        private Regex emailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public UsersManager()
        {
            try
            {
                _users = JsonFileHandler.ReadFile<User>(KeyStore.FilePaths.Users) ?? new List<User>();
                foreach(var user in _users)
                {
                    var firstname = user.UserName.Split(" ")[0].ToUpper();
                    if (NameCountMap.ContainsKey(firstname))
                        NameCountMap[firstname] += 1;
                    else
                        NameCountMap[firstname] = 1;
                }
                pinvalidator = new PincodeValidator();
            }
            catch
            {
                _users = new List<User>();
            }
        }
        public bool ValidatePincode(long pincode)
        {
            return pinvalidator.IsValidPinCode(pincode);
        }
        public bool AddUser(User user)
        {
            if (string.IsNullOrEmpty(user?.EmailID))
                return false;
            if (isExistingUser(user.EmailID))
                return false;
            user.UserId = GenerateUserId(user.UserName);            
            lock(_users)
                _users.Add(user);
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }

        public bool isExistingUser(string emailId)
        {
            if (!string.IsNullOrEmpty(GetUserIdByEmailId(emailId)))
                return true;
            return false;
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
        
        public bool ValidateUser(string id,string password)
        {
            if (emailPattern.Match(id).Success)
                return ValidateUserByEmail(id, password);
            else
                return ValidateUserByUserId(id, password);
        }

       
        public bool IsValidUserId(string id)
        {
            return _users.Exists(user => user.EmailID.Equals(id) || user.UserId.Equals(id));
        }
        public string GetUserIdByEmailId(string emailId)
        {
          var result= string.IsNullOrEmpty(emailId) ? null : _users.Where(user => string.Equals(emailId, user.EmailID)).FirstOrDefault();
            return result?.UserId;
        }

        
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

        private string GenerateUserId(string Name)
        {
            var firstName = Name.Split(" ")[0].ToUpper();
            if (!NameCountMap.ContainsKey(firstName))
            {
                NameCountMap.Add(firstName, 1);
                return firstName;
            }
            else
            {
                int currentCount = NameCountMap[firstName];
                NameCountMap[firstName] = currentCount + 1;
                return firstName + currentCount;
            }


        }
        private bool ValidateUserByUserId(string userId, string password)
        {
            return _users.Exists(user => string.Equals(userId, user.UserId) && string.Equals(password, user.Password));
           
        }

        private bool ValidateUserByEmail(string emailId, string password)
        {
            return _users.Exists(user => string.Equals(emailId, user.EmailID) && string.Equals(password, user.Password));
            
        }
        public User GetUserByIdOrEmail(string id)
        {
            if (emailPattern.Match(id).Success)
                return GetUserByEmailId(id);
            else
                return GetUserById(id);
        }

        public User GetUserById(string userId)
        {
            return string.IsNullOrEmpty(userId) ? null : _users.Where(user => string.Equals(userId, user.UserId)).FirstOrDefault();
        }

        public User GetUserByEmailId(string emailId)
        {
            return string.IsNullOrEmpty(emailId) ? null : _users.Where(user => string.Equals(emailId, user.EmailID)).FirstOrDefault();
        }
    }
}
