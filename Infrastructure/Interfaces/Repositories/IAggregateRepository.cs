using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAggregateRepository
    {
        IBaseDetailsRepository BaseDetail { get; }
        IAbilityModifierRepository AbilityModifier { get; }
        IDescriptionRepository Description { get; }
        IStoryRepository Story { get; }
        ISkillBonusesRepository SkillBonus { get; }
        IRaceLanguageRepository RaceLanguage { get; }
        INamesRepository Names { get; }
    }
}
