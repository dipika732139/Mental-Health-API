using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Service
{
    public class CommunityConnectResponse:List<PeopleDetails>
    {
    }

    public class PeopleDetails
    {
        public string Name;
        public string EmailId;
    }
}
