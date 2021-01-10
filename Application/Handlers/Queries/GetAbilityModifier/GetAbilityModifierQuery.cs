using Application.Abstractions;
using Domain.Models;
using Infrastructure.Entities;
using MediatR;

namespace Application.Handlers.Queries
{
    public class GetAbilityModifierQuery : IRequest<AbilityModifierDTO>
    {
        public int Id { get; set; }
    }
}
