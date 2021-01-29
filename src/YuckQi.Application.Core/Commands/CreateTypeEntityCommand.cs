using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Commands
{
    public class CreateTypeEntityCommand<TTypeEntity, TKey> : IRequest<Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
    }
}