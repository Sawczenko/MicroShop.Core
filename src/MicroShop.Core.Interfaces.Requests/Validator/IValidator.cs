using MicroShop.Core.Models.Requests;

namespace MicroShop.Core.Interfaces.Requests.Validator
{
    public interface IValidator : IValidatorRoot, IRequest<RequestResult>
    {
    }
}
