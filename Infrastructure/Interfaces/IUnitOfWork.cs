using Infrastructure.Interfaces.Repositories;
using System;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAbilityReferenceRepository AbilityReference { get; }
        IAlignmentRepository Alignment { get; }
        IGenderRepository Gender { get; }
        ILanguagesRepository Languages { get; }
        ISkillReferenceRepository SkillReference { get; }

        void AbortTransaction();
        void CompleteTransaction();
        void BeginTransaction();
    }
}
