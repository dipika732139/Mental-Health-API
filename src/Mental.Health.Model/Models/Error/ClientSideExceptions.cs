using Mental.Health.Model.Models.Error;
using System;
using System.Net;

namespace Mental.Health
{
    public static partial class ClientSideExceptions
    {
        public static BaseException ValidationFailure()
        {
            return new BaseException(FaultCodes.ValidationFailure, FaultMessages.ValidationFailure, HttpStatusCode.BadRequest);
        }
        public static BaseException InvalidUser()
        {
            return new BaseException(FaultCodes.InvalidUser, FaultMessages.InvalidUser, HttpStatusCode.Forbidden);
        }

        public static BaseException InvalidTest()
        {
            return new BaseException(FaultCodes.InvalidUser, FaultMessages.InvalidUser, HttpStatusCode.BadRequest);
        }
    }
}
