using Mental.Health.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class CommunityConnectService : ICommunityConnectService
    {
        private readonly ICommunityConnectComponent _communityConnectComponent;

        public CommunityConnectService(ICommunityConnectComponent communityConnectComponent)
        {
            _communityConnectComponent = communityConnectComponent;
        }
        public async Task<CommunityConnectResponse> ConnectPeoplewithin5Km(CommunityConnectRequest request)
        {
            CommunityConnectResponse responseList = new CommunityConnectResponse();
            Validations.EnsureValid(request, new CommunityConnectRequestValidator());
            var result = await _communityConnectComponent.FindPeopleNearin5KmRange(request.UserId);
            foreach (var pair in result)
            {
                var response = new PeopleDetails()
                {
                    Name = pair.Item1,
                    EmailId = pair.Item2

                };
                responseList.Add(response);
            }
            return responseList;

        }
        public async Task<CommunityConnectResponse> ConnectPeoplewithin10Km(CommunityConnectRequest request)
        {
            CommunityConnectResponse responseList = new CommunityConnectResponse();
            Validations.EnsureValid(request, new CommunityConnectRequestValidator());
            var result = await _communityConnectComponent.FindPeopleNearin10KmRange(request.UserId);
            foreach (var pair in result)
            {
                var response = new PeopleDetails()
                {
                    Name = pair.Item1,
                    EmailId = pair.Item2

                };
                responseList.Add(response);
            }
            return responseList;

        }
        public async Task<CommunityConnectResponse> ConnectPeoplewithin20Km(CommunityConnectRequest request)
        {
            CommunityConnectResponse responseList = new CommunityConnectResponse();
            Validations.EnsureValid(request, new CommunityConnectRequestValidator());
            var result = await _communityConnectComponent.FindPeopleNearin20KmRange(request.UserId);
            foreach (var pair in result)
            {
                var response = new PeopleDetails()
                {
                    Name = pair.Item1,
                    EmailId = pair.Item2

                };
                responseList.Add(response);
            }
            return responseList;

        }
        public async Task<CommunityConnectResponse> ConnectPeoplewithin30Km(CommunityConnectRequest request)
        {
            CommunityConnectResponse responseList = new CommunityConnectResponse();
            Validations.EnsureValid(request, new CommunityConnectRequestValidator());
            var result = await _communityConnectComponent.FindPeopleNearin30KmRange(request.UserId);
            foreach (var pair in result)
            {
                var response = new PeopleDetails()
                {
                    Name = pair.Item1,
                    EmailId = pair.Item2

                };
                responseList.Add(response);
            }
            return responseList;

        }


    }
}
