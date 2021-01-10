using Application.Abstractions;
using Microsoft.Extensions.Logging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class UpdateTestCommandHandler : BaseHandler<UpdateTestCommand, Unit>
    {
        public UpdateTestCommandHandler(ICoreAggregator coreAggregator) : base(coreAggregator)
        {
        }
        public override Task<Unit> HandleEx(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation("test logmessage", "Handling Request");
            throw new NotImplementedException();
        }
    }
}
