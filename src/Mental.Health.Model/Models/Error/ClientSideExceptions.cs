using Mental.Health.Model.Models.Error;
using System.Net;

namespace Mental.Health
{
    public static partial class ClientSideExceptions
    {
        public static BaseException ValidationFailure()
        {
            return new BaseException(FaultCodes.ValidationFailure, FaultMessages.ValidationFailure, HttpStatusCode.BadRequest);
        }
    }
}
