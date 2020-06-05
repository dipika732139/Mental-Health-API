using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public interface IUserLocationManager
    {
        Task<List<User>> FindPeopleNearinGivenKmRange(User user, double distance);
    }
}
