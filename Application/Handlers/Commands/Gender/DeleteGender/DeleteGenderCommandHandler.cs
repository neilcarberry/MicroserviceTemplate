using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public DeleteGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var Gender = UnitOfWork.Gender.SingleOrDefaultById(request.Id);
            UnitOfWork.Gender.Remove(Gender);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
