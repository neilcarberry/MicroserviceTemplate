using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public AddLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(AddLanguageCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.Languages.Add(Mapper.Map<Languages>(request.Language));
            UnitOfWork.CompleteTransaction();

            return Unit.Task;

        }
    }
}
