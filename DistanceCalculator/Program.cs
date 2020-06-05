//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;

//namespace DistanceCalculator
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
            
//                var codes = PinCodeReader.ReadZipCodesFromCsv(@"C:\Users\Sahil\Downloads\zipcode.csv");
//                codes.IsCaching = true;

//                Console.WriteLine("From 400076 to 401101 in miles: {0:0.##}", codes[400076].Distance(codes[401101], Measurement.Miles));
//                Console.WriteLine("From 400076 to 401101 in kilometers: {0:0.##}", codes[400076].Distance(codes[401101], Measurement.Kilometers));
//                Console.WriteLine("From 400076 to 401101 in miles: {0:0.##}",
//                    codes[400076] - codes[401101]);

//                Console.WriteLine("Find all zips < 25 miles from 13126:");
//                var distanced = codes.FindLessThanDistanceInMiles(codes[400076], 25);

//                if (distanced.Count() > 0)
//                {
//                    foreach (var code in codes.FindLessThanDistanceInMiles(codes[400076], 25))
//                    {
//                        Console.WriteLine("* {0} ({1:0.##} miles)", code.PinCode.Code, code.Distance);
//                    }
//                }

//                Console.WriteLine("Press any key to exit");
//                Console.ReadKey();
//        }
//    }   

//        public enum Measurement
//        {
//            Miles,
//            Kilometers
//        }

//  }
