namespace MicroShop.Core.Interfaces.Services
{
    public interface IMapperService
    {

        T Map<T>(object sourceObject);

    }
}
