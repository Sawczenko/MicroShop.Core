using MicroShop.Core.Interfaces.Requests.Validator;

namespace MicroShop.Core.Abstractions.Requests.Validators
{
    public abstract class ValidatorHandlerBase<TValidator> : IValidatorHandler<TValidator>
        where TValidator : IValidator
    {
        public abstract Task<bool> Handle(TValidator validator, CancellationToken cancellationToken);
    }
}
