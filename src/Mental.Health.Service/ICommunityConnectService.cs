using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public interface ICommunityConnectService
    {
        Task<CommunityConnectResponse> ConnectPeoplewithin5Km(CommunityConnectRequest request);
        Task<CommunityConnectResponse> ConnectPeoplewithin10Km(CommunityConnectRequest request);
        Task<CommunityConnectResponse> ConnectPeoplewithin20Km(CommunityConnectRequest request);
        Task<CommunityConnectResponse> ConnectPeoplewithin30Km(CommunityConnectRequest request);
    }
}
