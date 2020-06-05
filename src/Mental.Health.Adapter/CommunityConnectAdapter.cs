using Mental.Health.Adapter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public class CommunityConnectAdapter:ICommunityConnectAdapter
    {
        private IUserLocationManager userLocationManager;
        private IUsersManager userManager;

        public CommunityConnectAdapter(IUserLocationManager _userLocationManager,IUsersManager _userManager)
        {
            userLocationManager = _userLocationManager;
            userManager = _userManager;

        }
        public async Task<List<(string,string)>> FindPeopleNearin5KmRange(string userId)
        {
            var list = new List<(string, string)>();
            var user= userManager.GetUserByIdOrEmail(userId);
           var result= await userLocationManager.FindPeopleNearinGivenKmRange(user, 5);
            foreach(var val in result)
            {
                if (val.UserId != userId && val.EmailID != userId)
                    list.Add((val.UserName, val.EmailID));
            }
            return list;

        }
        public async Task<List<(string, string)>> FindPeopleNearin10KmRange(string userId)
        {
            var list = new List<(string, string)>();
            var user = userManager.GetUserByIdOrEmail(userId);
            var result = await userLocationManager.FindPeopleNearinGivenKmRange(user,10);
            foreach (var val in result)
            {
                if(val.UserId!=userId && val.EmailID!=userId)
                    list.Add((val.UserName, val.EmailID));
            }
            return list;

        }
        public async Task<List<(string, string)>> FindPeopleNearin20KmRange(string userId)
        {
            var list = new List<(string, string)>();
            var user = userManager.GetUserByIdOrEmail(userId);
            var result = await userLocationManager.FindPeopleNearinGivenKmRange(user, 20);
            foreach (var val in result)
            {
                if (val.UserId != userId && val.EmailID != userId)
                    list.Add((val.UserName, val.EmailID));
            }
            return list;

        }
        public async Task<List<(string, string)>> FindPeopleNearin30KmRange(string userId)
        {
            var list = new List<(string, string)>();
            var user = userManager.GetUserByIdOrEmail(userId);
            var result = await userLocationManager.FindPeopleNearinGivenKmRange(user,30);
            foreach (var val in result)
            {
                if (val.UserId != userId && val.EmailID != userId)
                    list.Add((val.UserName, val.EmailID));
            }
            return list;

        }
    }
}
