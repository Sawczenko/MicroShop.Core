using Ardalis.SmartEnum;
using System.Net;

namespace MicroShop.Core.Errors
{
    public abstract class Error : SmartEnum<Error>
    {
        public static readonly Error ERROR_UNKNOWN = new ErrorUnknown();

        public abstract string Message { get; }

        public abstract HttpStatusCode HttpStatusCode { get; }

        protected Error(string name, int value) : base(name, value) { }

        private sealed class ErrorUnknown : Error
        {
            public override string Message => "An unknown error has occurred. Contact the Administrator.";
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;

            public ErrorUnknown() : base(nameof(ERROR_UNKNOWN), 1000)
            {
            }
        }
    }
}