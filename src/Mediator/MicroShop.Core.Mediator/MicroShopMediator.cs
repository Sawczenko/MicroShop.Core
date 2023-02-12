using MediatR;

namespace MicroShop.Core.Mediator
{
    public class MicroShopMediator : MediatR.Mediator
    {
        public MicroShopMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }
    }
}