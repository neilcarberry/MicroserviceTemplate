using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyLanguageCommandHandler : IRequestHandler<ModifyLanguageCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public ModifyLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(ModifyLanguageCommand request, CancellationToken cancellationToken)
        {
            var Language = UnitOfWork.Languages.SingleOrDefaultById(request.Language.Id);
            Language = Mapper.Map<Languages>(request.Language);

            UnitOfWork.Languages.Update(Language);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
