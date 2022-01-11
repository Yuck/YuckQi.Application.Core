﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using YuckQi.Domain.Validation;
using YuckQi.Domain.Validation.Exceptions;
using YuckQi.Domain.Validation.Extensions;

namespace YuckQi.Application.Core.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Private Members

        private readonly String _failedValidationMessageId;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<AbstractValidator<TRequest>> _validators;

        #endregion


        #region Constructors

        public ValidationBehavior(IEnumerable<AbstractValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger, String failedValidationMessageId)
        {
            _validators = validators ?? Array.Empty<AbstractValidator<TRequest>>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _failedValidationMessageId = failedValidationMessageId;
        }

        #endregion


        #region Public Methods

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = Stopwatch.StartNew();
            var requestType = typeof(TRequest).Name;

            _logger.LogInformation("Validation of '{requestType}' started.", requestType);

            var results = _validators.Select(validator => validator.GetResult(request, _failedValidationMessageId)).ToList();
            var invalid = new Result(results.Where(t => ! t.IsValid).SelectMany(t => t.Detail).ToList());
            if (invalid.Detail.Any(t => t.Type == ResultType.Error))
            {
                _logger.LogInformation("Validation of '{requestType}' failed ({validationElapsed:g} elapsed).", requestType, stopwatch.Elapsed);

                throw new DomainValidationException(invalid);
            }

            _logger.LogInformation("Validation of '{requestType}' completed ({validationElapsed:g} elapsed).", requestType, stopwatch.Elapsed);

            return next();
        }

        #endregion
    }
}
