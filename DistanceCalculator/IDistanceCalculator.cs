using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IDistanceCalculator
    {
        bool IsPincodeValid(long pincode);
        Task<double> GetDistanceBetweenTwoPincodeInMiles(long first, long second);
        Task<double> GetDistanceBetweenTwoPincodeInKms(long first, long second);
        Task<IEnumerable<long>> GetAllPIncodesWithinDistanceInKms(long code, double distance);
        Task<IEnumerable<long>> GetAllPIncodesWithinDistanceInMiles(long code, double distance);
     //   static IDistanceCalculator GetInstance();
        

    }
}

