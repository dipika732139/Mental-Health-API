using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator
{
    internal  class PinCodeReader
    {
        public static PinCodes codes = new PinCodes();
        internal  PinCodes ReadPincodesFromCsv(string filepath)
        {           

            using (StreamReader reader = File.OpenText(filepath))
            {
                return ReadPinCodes(reader);
            }
        }

        private  PinCodes ReadPinCodes(StreamReader reader)
        {
           
            if (reader == null) { throw new ArgumentNullException("reader"); }
            string line = reader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var columns=line.Split(',');

                int code = 0;
                double lat = 0;
                double lon = 0;
                // skip lines that aren't valid
                if (Int32.TryParse(columns[1], out code) &&
                    double.TryParse(columns[2], out lat) &&
                    double.TryParse(columns[4], out lon)
                    )
                {
                    // there are a few duplicates due to state boundaries,
                    // ignore them
                    if (!codes.ContainsKey(code))
                    {
                        codes.Add(code, new PinCode()
                        {
                            State = columns[3],
                            Code = code,
                            Latitude = PinCode.ToRadians(lat),
                            Longitude = PinCode.ToRadians(lon),
                        });
                    }
                }
                line = reader.ReadLine();
            }
            return codes;
        }

        
    }
}
