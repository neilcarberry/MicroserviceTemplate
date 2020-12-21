using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddGenderCommandHandler : IRequestHandler<AddGenderCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public AddGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(AddGenderCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Gender.Add(Mapper.Map<Genders>(request.Gender));
            UnitOfWork.CompleteTransaction();

            return Unit.Task;

        }
    }
}
