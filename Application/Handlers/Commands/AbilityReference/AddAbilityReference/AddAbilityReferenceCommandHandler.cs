using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddAbilityReferenceCommandHandler : IRequestHandler<AddAbilityReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public AddAbilityReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(AddAbilityReferenceCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.AbilityReference.Add(Mapper.Map<AbilityReference>(request.AbilityReference));
            UnitOfWork.CompleteTransaction();

            return Unit.Task;

        }
    }
}
