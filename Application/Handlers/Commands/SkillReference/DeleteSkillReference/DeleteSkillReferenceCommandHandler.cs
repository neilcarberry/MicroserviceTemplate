using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteSkillReferenceCommandHandler : IRequestHandler<DeleteSkillReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public DeleteSkillReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(DeleteSkillReferenceCommand request, CancellationToken cancellationToken)
        {
            var SkillReference = UnitOfWork.SkillReference.SingleOrDefaultById(request.Id);
            UnitOfWork.SkillReference.Remove(SkillReference);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
