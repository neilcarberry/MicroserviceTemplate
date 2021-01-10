using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDatabaseContext _context;
        public List<IRepository> Repositories { get; }
        public IBaseDetailsRepository BaseDetail { get; }
        public IAbilityModifierRepository AbilityModifier { get; }
        public IDescriptionRepository Description { get; }
        public IStoryRepository Story { get; }
        public ISkillBonusesRepository SkillBonus { get; }
        public IRaceLanguageRepository RaceLanguage { get; }
        public INamesRepository Names { get; }

        public UnitOfWork(IDatabaseContext context, IAggregateRepository aggregateRepository)
        {
            _context = context;
            BaseDetail = aggregateRepository.BaseDetail;
            AbilityModifier = aggregateRepository.AbilityModifier;
            Description = aggregateRepository.Description;
            Story = aggregateRepository.Story;
            SkillBonus = aggregateRepository.SkillBonus;
            RaceLanguage = aggregateRepository.RaceLanguage;
            Names = aggregateRepository.Names;
            Repositories = new List<IRepository>();
            Repositories.Add(aggregateRepository.AbilityModifier);
            BeginTransaction();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return (IRepository<T>)Repositories.First(x => x.GetType().GetInterfaces().Where(x => x.FullName.Contains(typeof(T).Name)).Count() > 0);

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
            // _context.BeginTransaction();
        }
    }
}
