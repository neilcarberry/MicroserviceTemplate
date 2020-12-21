using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddSkillReferenceCommandHandler : IRequestHandler<AddSkillReferenceCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public AddSkillReferenceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(AddSkillReferenceCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.SkillReference.Add(Mapper.Map<SkillReference>(request.SkillReference));
            UnitOfWork.CompleteTransaction();

            return Unit.Task;

        }
    }
}
