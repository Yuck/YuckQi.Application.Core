using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using YuckQi.Application.Core.Abstract;
using YuckQi.Domain.Validation;
using YuckQi.Domain.Validation.Extensions;

namespace YuckQi.Application.Core.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IValidated, new()
{
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<AbstractValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<AbstractValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators ?? Array.Empty<AbstractValidator<TRequest>>();
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var stopwatch = Stopwatch.StartNew();
        var requestType = typeof(TRequest).Name;

        _logger?.LogInformation("Validation of '{requestType}' started.", requestType);

        if (_validators.Any())
        {
            var results = await Task.WhenAll(_validators.Select(validator => validator.GetResult(request, cancellationToken)));
            var invalid = new Result(results.Where(t => ! t.IsValid).SelectMany(t => t.Detail).ToList());
            if (invalid.Detail.Any(t => t.Type == ResultType.Error))
            {
                _logger?.LogInformation("Validation of '{requestType}' failed ({validationElapsed:g} elapsed).", requestType, stopwatch.Elapsed);

                return new TResponse { ValidationResults = results };
            }
        }
        else
        {
            _logger?.LogInformation("Validation of '{requestType}' does not have any validators configured.", requestType);
        }

        _logger?.LogInformation("Validation of '{requestType}' completed ({validationElapsed:g} elapsed).", requestType, stopwatch.Elapsed);

        return await next();
    }
}
