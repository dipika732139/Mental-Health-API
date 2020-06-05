using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator
{

    internal class PinCodes : Dictionary<long, PinCode>
    {
        private const double MaxDistance = 100.0;

        /// <summary>
        /// Gets and sets whether the PinCodes class caches all search results.
        /// </summary>
        public bool IsCaching { get; set; }
        /// <summary>
        /// Find all Zip Codes less than a specified distance
        /// </summary>
        /// <param name="startingPinCode">Provide the starting zip code as an object</param>
        /// <param name="distance">Maximum distance from starting zip code</param>
        /// <returns>List of ZipCodeDistance objects, sorted by distance.</returns>
        /// 
        private IEnumerable<PinCodeDistance> FindLessThanDistanceInMiles(PinCode startingPinCode, double distance)
        {
            if (distance > MaxDistance)
            {
                throw new ArgumentOutOfRangeException("distance",
                    string.Format("Must be less than {0}.", MaxDistance));
            }

            IEnumerable<PinCodeDistance> codes1 = null;
            if (startingPinCode.DistanceCache == null)
            {
                // grab all less than the MaxDistance in first pass
                codes1 = from c in this.Values
                         let d = c - startingPinCode
                         where (d <= MaxDistance)
                         orderby d
                         select new PinCodeDistance() { PinCode = c, Distance = d };
                // this might just be temporary storage depending on caching settings
                startingPinCode.DistanceCache = codes1;
            }
            else
            {
                // grab the cached copy
                codes1 = startingPinCode.DistanceCache;
            }
            List<PinCodeDistance> filtered = new List<PinCodeDistance>();

            foreach (PinCodeDistance pcd in codes1)
            {
                // since the list is pre-sorted, we can now drop out 
                // quickly and efficiently as soon as something doesn't
                // match
                if (pcd.Distance > distance)
                {
                    break;
                }
                filtered.Add(pcd);
            }

            // if no caching, don't leave the cached result in place
            if (!IsCaching) { startingPinCode.DistanceCache = null; }
            return filtered;
        }
        internal Task<List<long>> GetAllPincodesWithinWithinGivenKms(PinCode startingPinCode, double distance)
        {
            var pincodes = new List<long>();
            var PinCodeDistanceList=FindLessThanDistanceInMiles(startingPinCode, distance*0.621);
            foreach(var pdmap in PinCodeDistanceList)
            {
                pincodes.Add(pdmap.PinCode.Code);
            }
            return Task.FromResult(pincodes); ;
        }
        internal Task<List<long>> GetAllPincodesWithinWithinGivenMiles(PinCode startingPinCode, double distance)
        {
            var pincodes = new List<long>();
            var PinCodeDistanceList = FindLessThanDistanceInMiles(startingPinCode, distance);
            foreach (var pdmap in PinCodeDistanceList)
            {
                pincodes.Add(pdmap.PinCode.Code);
            }
            return Task.FromResult(pincodes);
        }
    }
    internal class PinCodeDistance
    {
        public PinCode PinCode { get; set; }
        public double Distance { get; set; }
    }

}
