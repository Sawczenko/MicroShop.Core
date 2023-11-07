﻿using MicroShop.Core.Interfaces.Requests.Manager;
using MicroShop.Core.Behaviours.Pipelines.Base;
using MicroShop.Core.Models.Exceptions;
using MicroShop.Core.Models.Requests;
using System.Diagnostics;
using System.Net;
using MediatR;

namespace MicroShop.Core.Behaviours.Pipelines.Requests.Manager
{
    public class ManagerPipeline<TRequest, TResponse> : ApplicationPipelineBase, IPipelineBehavior<TRequest, TResponse>
        where TRequest : IManagerRoot
    {
        private readonly ApplicationRequest applicationRequest;

        public ManagerPipeline(ApplicationRequest applicationRequest) : base(applicationRequest) 
        {
            this.applicationRequest = applicationRequest;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Activity activity = Activity.Current;

            activity?.Start()
                .AddTag("Manager", typeof(TRequest).Name)
                .AddEvent(new($"{typeof(TRequest).Name} - Started!"));

            applicationRequest.StartDate = DateTime.Now;

            try
            {
                var response = await next();

                applicationRequest.Response = response;
                applicationRequest.IsSuccessful = true;
                applicationRequest.StatusCode = HttpStatusCode.OK;

                return response;
            }
            catch (RequestException requestException)
            {
                SetException(requestException);
            }
            catch (Exception exception)
            {
                SetException(exception);
            }
            finally
            {
                applicationRequest.CompletionDate = DateTime.Now;
                TimeSpan duration = applicationRequest.CalculateDuration();

                activity?.AddEvent(new(typeof(TRequest).Name + $" - Ended! Duration: {duration.TotalMilliseconds} ms."));
            }

            return default;
        }
    }
}
