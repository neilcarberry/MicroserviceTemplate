using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddAlignmentCommandHandler : IRequestHandler<AddAlignmentCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public AddAlignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(AddAlignmentCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Alignment.Add(Mapper.Map<Alignment>(request.Alignment));
            UnitOfWork.CompleteTransaction();

            return Unit.Task;

        }
    }
}
