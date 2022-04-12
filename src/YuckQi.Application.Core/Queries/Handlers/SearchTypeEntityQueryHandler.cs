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

public class SearchTypeEntityQueryHandler<TTypeEntity, TKey> : IRequestHandler<SearchTypeEntityQuery<TTypeEntity, TKey>, Result<IPage<TTypeEntity>>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
{
    #region Private Members

    private readonly IMapper _mapper;
    private readonly ITypeEntityService<TTypeEntity, TKey> _types;

    #endregion


    #region Constructors

    public SearchTypeEntityQueryHandler(ITypeEntityService<TTypeEntity, TKey> types, IMapper mapper)
    {
        _types = types ?? throw new ArgumentNullException(nameof(types));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    #endregion


    #region Public Methods

    public Task<Result<IPage<TTypeEntity>>> Handle(SearchTypeEntityQuery<TTypeEntity, TKey> request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return _types.SearchAsync(_mapper.Map<TypeSearchCriteria>(request));
    }

    #endregion
}
