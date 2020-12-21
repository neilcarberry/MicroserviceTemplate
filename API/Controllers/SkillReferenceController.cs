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
    public class SkillReferenceController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<SkillReferenceDTO> GetSkillReference([FromRoute]GetSkillReferenceQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<SkillReferenceDTO>> GetSkillReferences()
        {
            return await Mediator.Send(new GetSkillReferencesQuery());
        }

        [HttpPost]
        public async Task<Unit> AddSkillReference(AddSkillReferenceCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteSkillReference(DeleteSkillReferenceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifySkillReference(ModifySkillReferenceCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}