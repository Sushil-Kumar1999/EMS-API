using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Api.Infrastructure
{
    public class ValidationErrorsResponse
    {
        private static readonly JsonSerializerSettings serializerSettings = new() { ContractResolver = new CamelCasePropertyNamesContractResolver(), Formatting = Formatting.None };

        private readonly List<ValidationError> _errors;

        private ValidationErrorsResponse()
        {
            _errors = new List<ValidationError>();
        }

        public ValidationErrorsResponse(string errorMessage)
            : this() => _errors.Add(new ValidationError(errorMessage));

        public ValidationErrorsResponse(IEnumerable<string> errorMessages)
            : this() => _errors.AddRange(errorMessages.Select(m => new ValidationError(m)));

        public IEnumerable<ValidationError> Errors => _errors;

        public string ToJson() => JsonConvert.SerializeObject(this, serializerSettings);
    }
}
