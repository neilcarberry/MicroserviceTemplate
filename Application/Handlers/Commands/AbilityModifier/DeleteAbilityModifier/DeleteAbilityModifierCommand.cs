using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Commands
{
    public class DeleteAbilityModifierCommand : IRequest
    {
        public int Id { get; set; }
    }
}
