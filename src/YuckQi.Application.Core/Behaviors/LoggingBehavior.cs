using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace YuckQi.Application.Core.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Private Members

        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        #endregion


        #region Constructors

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion


        #region Public Methods

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = Stopwatch.StartNew();
            var requestType = typeof(TRequest).Name;

            _logger.LogInformation("Handling '{requestType}' started.", requestType);

            var response = await next();

            _logger.LogInformation("Handling '{requestType}' completed ({requestElapsed:g} elapsed).", requestType, stopwatch.Elapsed);

            return response;
        }

        #endregion
    }
}
