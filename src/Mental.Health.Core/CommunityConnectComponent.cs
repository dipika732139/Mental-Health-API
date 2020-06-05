using Mental.Health.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Core
{
    public class CommunityConnectComponent:ICommunityConnectComponent
    {

        private ICommunityConnectAdapter communityConnectAdapter;
        public CommunityConnectComponent(ICommunityConnectAdapter _communityConnectAdapter)
        {
            communityConnectAdapter = _communityConnectAdapter;

        }
        public async Task<List<(string, string)>> FindPeopleNearin5KmRange(string userid)
        {
            return await communityConnectAdapter.FindPeopleNearin5KmRange(userid);            
        }

        public async Task<List<(string, string)>> FindPeopleNearin10KmRange(string userid)        
        {
            return await communityConnectAdapter.FindPeopleNearin10KmRange(userid);
        }

        public async Task<List<(string, string)>> FindPeopleNearin20KmRange(string userid)
        {
            return await communityConnectAdapter.FindPeopleNearin20KmRange(userid);
        }

        public async Task<List<(string, string)>> FindPeopleNearin30KmRange(string userid)
        {
            return await communityConnectAdapter.FindPeopleNearin30KmRange(userid);
        }

    }
}
