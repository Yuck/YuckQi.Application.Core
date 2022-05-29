using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Validation;
using YuckQi.Extensions.Mapping.Abstractions;

namespace YuckQi.Application.Core.Commands.Handlers;

public class CreateTypeEntityCommandHandler<TTypeEntity, TIdentifier> : IRequestHandler<CreateTypeEntityCommand<TTypeEntity, TIdentifier>, Result<TTypeEntity>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : struct
{
    #region Private Members

    private readonly ITypeEntityService<TTypeEntity, TIdentifier> _types;
    private readonly IMapper _mapper;

    #endregion


    #region Constructors

    public CreateTypeEntityCommandHandler(ITypeEntityService<TTypeEntity, TIdentifier> types, IMapper mapper)
    {
        _types = types ?? throw new ArgumentNullException(nameof(types));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    #endregion


    #region Public Methods

    public Task<Result<TTypeEntity>> Handle(CreateTypeEntityCommand<TTypeEntity, TIdentifier> request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var entity = _mapper.Map<TTypeEntity>(request);
        var result = _types.CreateAsync(entity);

        return result;
    }

    #endregion
}
