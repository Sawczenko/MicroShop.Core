using MicroShop.Core.Abstractions.Services.Pagination;
using MicroShop.Core.Interfaces.Requests.Queries;
using MicroShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace MicroShop.Catalog.Application.Pipelines
{
    internal class PaginationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IPaginationQuery<TResponse>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPaginationService paginationService;

        public PaginationPipeline(IHttpContextAccessor httpContextAccessor, IPaginationService paginationService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.paginationService = paginationService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            PaginationService paginationServiceFromHeader = GetPaginationFromHeader();

            paginationService.CurrentPage = paginationServiceFromHeader.CurrentPage;
            paginationService.PageSize = paginationServiceFromHeader.PageSize;

            var response = await next();

            return response;
        }

        private PaginationService GetPaginationFromHeader()
        {
            var headers = httpContextAccessor.HttpContext.Request.Headers;

            var paginationServiceExists = headers.ContainsKey("Pagination");

            if (paginationServiceExists)
            {
                //TODO Parse From Json
                var paginationService = headers["Pagination"];
            }

            return new PaginationService();
        }

    }
}
