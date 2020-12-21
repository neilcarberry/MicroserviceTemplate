using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyAbilityReferenceCommandHandler : IRequestHandler<ModifyAbilityReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public ModifyAbilityReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(ModifyAbilityReferenceCommand request, CancellationToken cancellationToken)
        {
            var AbilityReference = UnitOfWork.AbilityReference.SingleOrDefaultById(request.AbilityReference.Id);
            AbilityReference = Mapper.Map<AbilityReference>(request.AbilityReference);

            UnitOfWork.AbilityReference.Update(AbilityReference);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
