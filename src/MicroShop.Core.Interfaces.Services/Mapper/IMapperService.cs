﻿namespace MicroShop.Core.Interfaces.Services.Mapper
{
    public interface IMapperService
    {
        T Map<T>(object sourceObject);

        TDestination Map<TSource, TDestination>(TSource sourceObject);
    }
}
