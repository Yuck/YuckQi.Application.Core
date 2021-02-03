using MediatR;
using YuckQi.Domain.Aspects.Abstract;
using YuckQi.Domain.Entities.Abstract;
using YuckQi.Domain.Validation;

namespace YuckQi.Application.Core.Commands
{
    public class CreateTypeEntityCommand<TTypeEntity, TKey> : IRequest<Result<TTypeEntity>> where TTypeEntity : IEntity<TKey>, IType where TKey : struct
    {
        #region Properties

        public string Name { get; }
        public string ShortName { get; }

        #endregion


        #region Constructors

        public CreateTypeEntityCommand(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        #endregion
    }
}