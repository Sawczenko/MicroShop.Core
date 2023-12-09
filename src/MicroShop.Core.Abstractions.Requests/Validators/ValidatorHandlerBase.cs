using MicroShop.Core.Interfaces.Requests.Validator;
using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Abstractions.Requests.Validators
{
    public abstract class ValidatorHandlerBase<TValidator> : IValidatorHandler<TValidator>
        where TValidator : IValidator
    {
        public abstract Task<RequestResult> Handle(TValidator validator, CancellationToken cancellationToken);
    }
}
