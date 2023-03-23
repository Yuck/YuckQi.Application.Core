using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Services.Models;
using YuckQi.Domain.Validation;
using YuckQi.Domain.ValueObjects.Abstract;
using YuckQi.Extensions.Mapping.Abstractions;

namespace YuckQi.Application.Core.Queries.Handlers;

public class SearchTypeEntityQueryHandler<TTypeEntity, TIdentifier> : IRequestHandler<SearchTypeEntityQuery<TTypeEntity, TIdentifier>, Result<IPage<TTypeEntity>>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : IEquatable<TIdentifier>
{
    private readonly IMapper _mapper;
    private readonly ITypeEntityService<TTypeEntity, TIdentifier> _types;

    public SearchTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TIdentifier> types, IMapper mapper)
    {
        _types = types ?? throw new ArgumentNullException(nameof(types));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<Result<IPage<TTypeEntity>>> Handle(SearchTypeEntityQuery<TTypeEntity, TIdentifier> request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return _types.Search(_mapper.Map<TypeSearchCriteria>(request), cancellationToken);
    }
}
