using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace API.Interceptor
{
    public class GenericPreProcessorBehavior<TRequest> : IRequestPreProcessor<TRequest> 
    {
        private readonly ILogger _logger;

        public GenericPreProcessorBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User Details
            _logger.LogInformation("DDDTemplate Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}