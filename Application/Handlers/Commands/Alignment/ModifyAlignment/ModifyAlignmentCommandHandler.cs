using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyAlignmentCommandHandler : IRequestHandler<ModifyAlignmentCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public ModifyAlignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(ModifyAlignmentCommand request, CancellationToken cancellationToken)
        {
            var Alignment = UnitOfWork.Alignment.SingleOrDefaultById(request.Alignment.Id);
            Alignment = Mapper.Map<Alignment>(request.Alignment);

            UnitOfWork.Alignment.Update(Alignment);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
