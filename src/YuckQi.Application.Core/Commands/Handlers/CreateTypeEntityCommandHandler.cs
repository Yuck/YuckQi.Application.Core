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

public class CreateTypeEntityCommandHandler<TTypeEntity, TIdentifier> : IRequestHandler<CreateTypeEntityCommand<TTypeEntity, TIdentifier>, Result<TTypeEntity>> where TTypeEntity : IEntity<TIdentifier>, IType where TIdentifier : IEquatable<TIdentifier>
{
    private readonly ITypeEntityService<TTypeEntity, TIdentifier> _types;
    private readonly IMapper _mapper;

    public CreateTypeEntityCommandHandler(ITypeEntityService<TTypeEntity, TIdentifier> types, IMapper mapper)
    {
        _types = types ?? throw new ArgumentNullException(nameof(types));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<Result<TTypeEntity>> Handle(CreateTypeEntityCommand<TTypeEntity, TIdentifier> request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var entity = _mapper.Map<TTypeEntity>(request);
        var result = _types.Create(entity, cancellationToken);

        return result;
    }
}
