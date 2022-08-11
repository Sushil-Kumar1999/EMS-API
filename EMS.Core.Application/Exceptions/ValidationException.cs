using System;
using System.Collections.Generic;

namespace EMS.Core.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<string> errors) 
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}
