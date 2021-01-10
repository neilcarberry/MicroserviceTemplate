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
    public class RaceSkillBonusesController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<SkillBonusDTO> GetSkillBonus([FromRoute]GetSkillBonusQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<SkillBonusDTO>> GetSkillBonuss()
        {
            return await Mediator.Send(new GetSkillBonussQuery());
        }

        [HttpPost]
        public async Task<Unit> AddSkillBonus(AddSkillBonusCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteSkillBonus(DeleteSkillBonusCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifySkillBonus(ModifySkillBonusCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}