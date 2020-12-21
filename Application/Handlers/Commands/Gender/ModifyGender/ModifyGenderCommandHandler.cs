using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class ModifyGenderCommandHandler : IRequestHandler<ModifyGenderCommand>
    {
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public ModifyGenderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public Task<Unit> Handle(ModifyGenderCommand request, CancellationToken cancellationToken)
        {
            var Gender = UnitOfWork.Gender.SingleOrDefaultById(request.Gender.Id);
            Gender = Mapper.Map<Genders>(request.Gender);

            UnitOfWork.Gender.Update(Gender);
            UnitOfWork.CompleteTransaction();

            return Unit.Task;
        }
    }
}
