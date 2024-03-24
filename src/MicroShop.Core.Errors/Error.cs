using Ardalis.SmartEnum;
using System.Net;

namespace MicroShop.Core.Errors
{
    public abstract class Error : SmartEnum<Error>
    {
        public static readonly Error ERROR_NONE= new ErrorNone();

        public static readonly Error ERROR_UNKNOWN = new ErrorUnknown();

        public string Message { get; init; }

        public abstract HttpStatusCode HttpStatusCode { get; }

        protected Error(string name, int value) : base(name, value) { }

        private sealed class ErrorNone : Error
        {
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.OK;

            public ErrorNone() : base(nameof(ERROR_NONE), 1000)
            {
                Message = string.Empty;
            }
        }

        private sealed class ErrorUnknown : Error
        {
            public override HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;

            public ErrorUnknown() : base(nameof(ERROR_UNKNOWN), 1001)
            {
                Message = "ERROR_UNKNOWN";
            }
        }
    }
}