using MicroShop.Core.Errors;

namespace MicroShop.Core.Models.Exceptions
{
    public class RequestException : Exception
    {
        public Error Error { get; set; }

        public List<string> Parameters { get; set; }

        public RequestException(Error error) : base(error.Message)
        {
            Error = error;
        }

        private RequestException(Error error, string message, params string[] parameters) : base(message)
        {
            Error = error;
            Parameters = parameters.ToList();
        }

        public static RequestException CreateParametrized(Error error, params string[] parameters)
        {
            string message = error.Message;

            for (int i = 0; i < parameters.Length; i++)
            {
                message = error.Message.Replace("{" + i + "}", parameters[i]);
            }

            return new RequestException(error, message, parameters);
        }

    }
}
