using Application.Handlers;
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
    public class AbilityReferenceController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<AbilityReferenceDTO> GetAbilityReference([FromRoute]GetAbilityReferenceQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<AbilityReferenceDTO>> GetAbilityReferences()
        {
            return await Mediator.Send(new GetAbilityReferencesQuery());
        }

        [HttpPost]
        public async Task<Unit> AddAbilityReference(AddAbilityReferenceCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteAbilityReference(DeleteAbilityReferenceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyAbilityReference(ModifyAbilityReferenceCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}