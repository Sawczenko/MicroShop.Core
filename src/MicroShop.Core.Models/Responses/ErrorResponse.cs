namespace MicroShop.Core.Models.Responses
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public static ErrorResponse CreateResponse(string message, int errorCode)
        {
            return new ErrorResponse { ErrorCode = errorCode, Message = message };
        }
    }
}
