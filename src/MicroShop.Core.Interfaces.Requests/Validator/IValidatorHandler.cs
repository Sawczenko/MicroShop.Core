using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Validator
{
    public interface IValidatorHandler<in TValidator> : IRequestHandler<TValidator, RequestResult>
        where TValidator : IValidator
    {
    }
}
