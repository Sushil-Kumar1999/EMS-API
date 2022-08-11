using System;

namespace EMS.Core.Application.Exceptions
{
    public class InvalidLoginAttemptException : Exception
    {
        public InvalidLoginAttemptException(string message)
            : base(message)
        {
        }
    }
}
