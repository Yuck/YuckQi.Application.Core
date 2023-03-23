﻿using System.Collections.Generic;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Abstract;

public interface IValidated
{
    IReadOnlyCollection<Result> ValidationResults { get; internal set; }
}
