using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public class UserLocationManager:IUserLocationManager
    { 
        private IDistanceCalculator distanceCalculator;
        private IUsersManager usersManager;
        public UserLocationManager(IUsersManager _userManager)
        {
            distanceCalculator = DistanceCalculator.GetInstance();
            usersManager = _userManager;

        }
        public async Task<List<User>> FindPeopleNearinGivenKmRange(User user,double distance)
        {
            List<User> allUsers = new List<User>();
            var pincodes = await distanceCalculator.GetAllPIncodesWithinDistanceInKms(user.Pincode,distance);            
            foreach(var code in pincodes)
            {
                var users= usersManager.GetAllUsers().Where(currentUser => currentUser.Pincode.Equals(code) && (currentUser.ConnectWithOthers==true));
                foreach(var val in users)
                    allUsers.Add(val);
            }

            return allUsers;
            
        }
    }
}
