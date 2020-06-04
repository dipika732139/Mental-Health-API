using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public class UserRegistrationAdapter : IUserRegistrationAdapter
    {
        private IUsersManager _usersManager;
        public UserRegistrationAdapter(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        public Task<string> GetUserId(string EmailID)
        {
            return Task.FromResult(_usersManager.GetUserIdByEmailId(EmailID));
        }

        public Task<bool> IsValidEmailID(string EmailID)
        {
            return Task.FromResult(!_usersManager.isExistingUser(EmailID));
        }

        public Task<bool> IsValidUser(string userId)
        {
            return Task.FromResult(_usersManager.IsValidUserId(userId));

        }

        public Task<bool> LoginUser(string UserID, string Password)
        {
            return Task.FromResult(_usersManager.ValidateUser(UserID, Password));
        }

        public Task<bool> RegisterUserAccount(string EmailID, string Name, string Password, string Gender, int Age, string Country, long PhoneNumber, long Pincode, bool ConnectWithOthers)
        {
            Gender gender;
            Enum.TryParse(Gender,out gender);
            return Task.FromResult(_usersManager.AddUser(new User()
            {
                EmailID = EmailID,
                UserName = Name,
                Age = Age,
                Gender = gender,
                Country = Country,
                PhoneNumber = PhoneNumber,
                Pincode = Pincode,
                Password = Password,
                ConnectWithOthers = ConnectWithOthers
            }));
        }
    }
}
