using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseDetailsRepository BaseDetail { get; }
        IAbilityModifierRepository AbilityModifier { get; }
        IDescriptionRepository Description { get; }
        IStoryRepository Story { get; }
        ISkillBonusesRepository SkillBonus { get; }
        IRaceLanguageRepository RaceLanguage { get; }
        INamesRepository Names { get; }
        public List<IRepository> Repositories { get; }
        IRepository<T> GetRepository<T>() where T : class;
        void AbortTransaction();
        void CompleteTransaction();
        void BeginTransaction();
    }
}
