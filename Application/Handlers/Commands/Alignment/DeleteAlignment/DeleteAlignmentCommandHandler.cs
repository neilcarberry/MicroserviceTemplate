using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteAlignmentCommandHandler : IRequestHandler<DeleteAlignmentCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public DeleteAlignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(DeleteAlignmentCommand request, CancellationToken cancellationToken)
        {
            var Alignment = UnitOfWork.Alignment.SingleOrDefaultById(request.Id);
            UnitOfWork.Alignment.Remove(Alignment);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
