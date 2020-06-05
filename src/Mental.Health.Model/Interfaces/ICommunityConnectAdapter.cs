using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface ICommunityConnectAdapter
    {
        //returns Name and EmailId of people nearby

        Task<List<(string, string)>> FindPeopleNearin5KmRange(string userid);
            
        Task<List<(string, string)>> FindPeopleNearin10KmRange(string userid);
            
        Task<List<(string, string)>> FindPeopleNearin20KmRange(string userid);
            
        Task<List<(string, string)>> FindPeopleNearin30KmRange(string userid);
           
        
    }

}

