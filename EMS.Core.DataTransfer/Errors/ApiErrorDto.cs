namespace EMS.Core.DataTransfer.Errors
{
    public class ApiErrorDto
    {
        public ApiErrorDto(string message, string errorReference, string details)
        {
            Message = message;
            ErrorReference = errorReference;
            Details = details;
        }

        public string Message { get; }
        public string ErrorReference { get; }
        public string Details { get; }
    }
}
