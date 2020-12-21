using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public DeleteLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var Language = UnitOfWork.Languages.SingleOrDefaultById(request.Id);
            UnitOfWork.Languages.Remove(Language);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
