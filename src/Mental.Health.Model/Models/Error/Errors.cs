using Mental.Health.Model.Models.Error;
using System.Net;

namespace Mental.Health
{
    public static partial class Errors
    {
        public static partial class ClientSide
        {
            public static BaseException ValidationFailure()
            {
                return new BaseException(FaultCodes.ValidationFailure, FaultMessages.ValidationFailure, HttpStatusCode.BadRequest);
            }
        }
    }
}
