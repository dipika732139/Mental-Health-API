using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    internal class PinCode
    {
        private double _cosLatitude = 0.0;
        private double _latitutde;
        private IEnumerable<PinCodeDistance> _cachedZipDistance;
        /// <summary>
        /// Two-digit state code
        /// </summary>
        internal string State { get; set; }

        /// <summary>
        /// 6 digit Postal Code
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// Latitude, in Radians
        /// </summary>
        internal double Latitude
        {
            get { return _latitutde; }
            set
            {
                _latitutde = value;
                _cosLatitude = Math.Cos(value);
            }
        }

        /// <summary>
        /// Precomputed value of the Cosine of Latitutde
        /// </summary>
        private double CosineOfLatitutde
        {
            get { return _cosLatitude; }
        }
        /// <summary>
        /// Longitude, in Radians
        /// </summary>
        internal double Longitude { get; set; }

        internal double Distance(PinCode compare)
        {
            return DistanceCalc(compare, Measurement.Miles);
        }

        /// <summary>
        /// Computes the distance between two zip codes using the Haversine formula
        /// (http://en.wikipedia.org/wiki/Haversine_formula).
        /// </summary>
        /// <param name="compare"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        internal Task<double> Distance(PinCode compare, Measurement m)
        {
            double dLon = compare.Longitude - this.Longitude;
            double dLat = compare.Latitude - this.Latitude;

            double a = Math.Pow(Math.Sin(dLat / 2.0), 2) +
                    this.CosineOfLatitutde *
                    compare.CosineOfLatitutde *
                    Math.Pow(Math.Sin(dLon / 2.0), 2.0);

            double c = 2 * Math.Asin(Math.Min(1.0, Math.Sqrt(a)));
            double d = (m == Measurement.Miles ? 3956 : 6367) * c;

            return Task.FromResult(d);
        }

        internal double DistanceCalc(PinCode compare, Measurement m)
        {
            double dLon = compare.Longitude - this.Longitude;
            double dLat = compare.Latitude - this.Latitude;

            double a = Math.Pow(Math.Sin(dLat / 2.0), 2) +
                    this.CosineOfLatitutde *
                    compare.CosineOfLatitutde *
                    Math.Pow(Math.Sin(dLon / 2.0), 2.0);

            double c = 2 * Math.Asin(Math.Min(1.0, Math.Sqrt(a)));
            double d = (m == Measurement.Miles ? 3956 : 6367) * c;

            return d;
        }
        public static double operator -(PinCode z1, PinCode z2)
        {
            if (z1 == null || z2 == null) { throw new ArgumentNullException(); }
            return z1.Distance(z2);
        }

        internal static double ToRadians(double d)
        {
            return (d / 180) * Math.PI;
        }

        internal IEnumerable<PinCodeDistance> DistanceCache
        {
            get
            {
                return _cachedZipDistance;
            }
            set
            {
                _cachedZipDistance = value;
            }
        }
    }
}
