namespace MicroShop.Core.Interfaces.Requests.Validator
{
    public interface IValidatorHandler<in TValidator> : IRequestHandler<TValidator, bool>
        where TValidator : IValidator
    {
    }
}
