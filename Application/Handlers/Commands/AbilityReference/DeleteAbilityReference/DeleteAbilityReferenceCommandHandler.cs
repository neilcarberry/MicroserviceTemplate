using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteAbilityReferenceCommandHandler : IRequestHandler<DeleteAbilityReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public DeleteAbilityReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(DeleteAbilityReferenceCommand request, CancellationToken cancellationToken)
        {
            var AbilityReference = UnitOfWork.AbilityReference.SingleOrDefaultById(request.Id);
            UnitOfWork.AbilityReference.Remove(AbilityReference);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
