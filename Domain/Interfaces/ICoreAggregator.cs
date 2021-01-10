using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Abstractions
{
    public interface ICoreAggregator
    {
        ILoggerFactory Logger { get; set; }
        IUnitOfWork UnitOfWork { get; set; }
        IMediator Mediator { get; set; }
        IMapper Mapper { get; set; }
    }
}
