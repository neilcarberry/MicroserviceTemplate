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
    public class RaceLanguageController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<RaceLanguageDTO> GetRaceLanguage([FromRoute]GetRaceLanguageQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<RaceLanguageDTO>> GetRaceLanguages()
        {
            return await Mediator.Send(new GetRaceLanguagesQuery());
        }

        [HttpPost]
        public async Task<Unit> AddRaceLanguage(AddRaceLanguageCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteRaceLanguage(DeleteRaceLanguageCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyRaceLanguage(ModifyRaceLanguageCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}