using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public static readonly object syncRoot=new object();
        private static DistanceCalculator _instance;
        public static DistanceCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new DistanceCalculator();
                        return _instance;
                    }
                }
                return _instance;
                
            }
        }
        private DistanceCalculator()
        {
           var reader= new PinCodeReader();
            reader.ReadPincodesFromCsv(@"C:\Users\Sahil\Downloads\zipcode.csv");
        }

        public bool IsPincodeValid(long pincode)
        {
            return PinCodeReader.codes.ContainsKey(pincode);
        }

        public static IDistanceCalculator GetInstance()
        {
            return Instance;
        }
        public async Task<IEnumerable<long>> GetAllPIncodesWithinDistanceInKms(long code, double distance)
        {

            var FromPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(code)).FirstOrDefault().Value;
            return await PinCodeReader.codes.GetAllPincodesWithinWithinGivenKms(FromPinCode, distance);
        }

        public async Task<IEnumerable<long>> GetAllPIncodesWithinDistanceInMiles(long code, double distance)
        {

            var FromPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(code)).FirstOrDefault().Value;
            return await PinCodeReader.codes.GetAllPincodesWithinWithinGivenMiles(FromPinCode, distance);
        }

        public async Task<double> GetDistanceBetweenTwoPincodeInKms(long first, long second)
        {
            var FromPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(first)).FirstOrDefault().Value;
            var ToPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(second)).FirstOrDefault().Value;
            return await FromPinCode.Distance(ToPinCode,Measurement.Kilometers);
        }

        public async Task<double> GetDistanceBetweenTwoPincodeInMiles(long first, long second)
        {
            var FromPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(first)).FirstOrDefault().Value;
            var ToPinCode = PinCodeReader.codes.Where(x => x.Key.Equals(second)).FirstOrDefault().Value;
            return await FromPinCode.Distance(ToPinCode, Measurement.Miles);
        }

    }
}
