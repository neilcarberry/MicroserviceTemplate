using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Abstractions
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected ILogger<TRequest> Logger { get; private set; }
        protected IMediator Mediator { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IMapper Mapper { get; private set; }
        public ICoreAggregator CoreAggregator
        {
            set
            {
                Logger = value.Logger.CreateLogger<TRequest>();
                Mediator = value.Mediator;
                UnitOfWork = value.UnitOfWork;
                Mapper = value.Mapper;
            }
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