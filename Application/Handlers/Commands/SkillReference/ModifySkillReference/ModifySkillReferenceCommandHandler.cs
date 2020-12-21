using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifySkillReferenceCommandHandler : IRequestHandler<ModifySkillReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public ModifySkillReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(ModifySkillReferenceCommand request, CancellationToken cancellationToken)
        {
            var SkillReference = UnitOfWork.SkillReference.SingleOrDefaultById(request.SkillReference.Id);
            SkillReference = Mapper.Map<SkillReference>(request.SkillReference);

            UnitOfWork.SkillReference.Update(SkillReference);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
