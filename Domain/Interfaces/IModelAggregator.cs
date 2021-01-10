using AutoMapper;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IModelAggregator
    {
        ILoggerFactory Logger { get; set; }
        IUnitOfWork UnitOfWork { get; set; }
        IMapper Mapper { get; set; }
    }
}
