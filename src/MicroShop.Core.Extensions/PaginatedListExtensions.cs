using Microsoft.EntityFrameworkCore;
using MicroShop.Core.Models;

namespace MicroShop.Core.Extensions
{
    public static class PaginatedListExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken token = default)
        {
            var count = await source.CountAsync(token);

            if (count > 0)
            {
                var amountToSkip = GetAmountToSkip(pageNumber, pageSize);

                var items = await source
                    .Skip(amountToSkip)
                    .Take(pageSize)
                    .ToListAsync(token);
                return new PagedList<T>(items, count, pageNumber, pageSize);
            }

            return new(Enumerable.Empty<T>(), default, default, default);
        }

        private static int GetAmountToSkip(int pageNumber, int pageSize)
        {
            var skip = pageNumber * pageSize;

            if (skip < 0)
            {
                skip = 0;
            }

            return skip;
        }
    }
}