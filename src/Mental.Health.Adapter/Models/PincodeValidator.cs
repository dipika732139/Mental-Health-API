using Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Adapter.Models
{
    public class PincodeValidator
    {

        public bool IsValidPinCode(long pincode)
        {
           return DistanceCalculator.GetInstance().IsPincodeValid(pincode);

        }
    }
}
