using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDatabaseContext _context;
        public IAbilityReferenceRepository AbilityReference { get; }
        public IAlignmentRepository Alignment { get; }
        public IGenderRepository Gender { get; }
        public ILanguagesRepository Languages { get; }
        public ISkillReferenceRepository SkillReference { get; }

        public UnitOfWork(IDatabaseContext context, IAbilityReferenceRepository abilityReference, IAlignmentRepository alignment, IGenderRepository gender, ILanguagesRepository language,
                          ISkillReferenceRepository skillReference)
        {
            _context = context;

            AbilityReference = abilityReference;
            Alignment = alignment;
            Gender = gender;
            Languages = language;
            SkillReference = skillReference;

            BeginTransaction();
        }

        public void AbortTransaction()
        {
            _context.AbortTransaction();
        }

        public void CompleteTransaction()
        {
            _context.CompleteTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }
    }
}
