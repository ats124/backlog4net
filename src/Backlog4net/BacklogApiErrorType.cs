using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net
{
    public enum BacklogApiErrorType
    {
        Undefined = -1,
        InternalError = 1,
        LicenceError = 2,
        LicenceExpiredError = 3,
        AccessDeniedError = 4,
        UnauthorizedOperationError = 5,
        NoResourceError = 6,
        InvalidRequestError = 7,
        SpaceOverCapacityError = 8,
        ResourceOverflowError = 9,
        TooLargeFileError = 10,
        AuthenticationError = 11,
    }
}
