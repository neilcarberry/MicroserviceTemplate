using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IAbilityModifierRepository : IRepository<AbilityModifier>
    {
        void test();
    }
}
