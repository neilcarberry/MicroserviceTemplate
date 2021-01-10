using AutoMapper;
using Domain.Models;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public abstract class BaseHandler2<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
                                                       where TRequest : IRequest<TResponse>
                                                       
    {
        protected readonly ILogger<TRequest> Logger;
        protected readonly IMediator Mediator;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly ICoreAggregator CoreAggregator;
        protected BaseHandler2(ICoreAggregator coreAggregator)
        {
            UnitOfWork = coreAggregator.UnitOfWork;
            Mediator = coreAggregator.Mediator;
            Mapper = coreAggregator.Mapper;
            Logger = coreAggregator.Logger.CreateLogger<TRequest>();
            CoreAggregator = coreAggregator;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"----- Handling command: {request}");
                var result = await HandleEx(request, cancellationToken);
                UnitOfWork.CompleteTransaction();
                return result;
            }
            catch (BaseHttpException bex)
            {
                UnitOfWork.AbortTransaction();
                throw bex;
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"----- Error during command: {ex.Message}");
                UnitOfWork.AbortTransaction();
                return default;
            }
        }

        public abstract Task<TResponse> HandleEx(TRequest request, CancellationToken cancellationToken);

    }
}