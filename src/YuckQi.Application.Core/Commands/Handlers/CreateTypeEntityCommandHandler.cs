using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Validation;
using YuckQi.Extensions.Mapping.Abstractions;

namespace YuckQi.Application.Core.Commands.Handlers
{
    public class CreateTypeEntityCommandHandler<TTypeEntity, TKey> : IRequestHandler<CreateTypeEntityCommand<TTypeEntity, TKey>, Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Private Members

        private readonly ITypeEntityService<TTypeEntity, TKey> _components;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors

        public CreateTypeEntityCommandHandler(ITypeEntityService<TTypeEntity, TKey> components, IMapper mapper)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Public Methods

        public Task<Result<TTypeEntity>> Handle(CreateTypeEntityCommand<TTypeEntity, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var entity = _mapper.Map<TTypeEntity>(request);
            var result = _components.CreateAsync(entity);

            return result;
        }

        #endregion
    }
}
