using Application.Handlers.Commands;
using Application.Handlers.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AbilityModifierController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<AbilityModifierDTO> GetAbilityModifier([FromRoute]GetAbilityModifierQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<AbilityModifierDTO>> GetAbilityModifiers()
        {
            return await Mediator.Send(new GetAbilityModifiersQuery());
        }

        [HttpPost]
        public async Task<Unit> AddAbilityModifier(AddAbilityModifierCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteAbilityModifier(DeleteAbilityModifierCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyAbilityModifier(ModifyAbilityModifierCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}