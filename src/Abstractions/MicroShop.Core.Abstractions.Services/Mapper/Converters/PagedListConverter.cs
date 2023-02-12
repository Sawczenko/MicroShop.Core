using MicroShop.Core.Models;
using AutoMapper;

namespace MicroShop.Core.Abstractions.Services.Mapper.Converters
{
    internal class PagedListConverter<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>>
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination,
            ResolutionContext context)
        {

            if (source is null)
            {
                return new PagedList<TDestination>(Enumerable.Empty<TDestination>(), default, default, default);
            }

            if (destination == null)
            {
                destination = new PagedList<TDestination>(Enumerable.Empty<TDestination>(), source.TotalCount, source.PageNumber, source.PageSize);
            }

            foreach (var item in source)
            {
                var dest = context.Mapper.Map<TSource, TDestination>(item);
                destination.Add(dest);
            }

            return destination;
        }
    }
}
