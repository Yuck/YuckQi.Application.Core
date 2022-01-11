using System;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Services.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Commands.Handlers
{
    public class CreateTypeEntityCommandHandler<TTypeEntity, TKey> : IRequestHandler<CreateTypeEntityCommand<TTypeEntity, TKey>, Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Private Members

        private readonly ITypeEntityService<TTypeEntity, TKey> _components;

        #endregion


        #region Constructors

        public CreateTypeEntityCommandHandler(ITypeEntityService<TTypeEntity, TKey> components)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
        }

        #endregion


        #region Public Methods

        public Task<Result<TTypeEntity>> Handle(CreateTypeEntityCommand<TTypeEntity, TKey> request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var entity = request.Adapt<TTypeEntity>();
            var result = _components.CreateAsync(entity);

            return result;
        }

        #endregion
    }
}
