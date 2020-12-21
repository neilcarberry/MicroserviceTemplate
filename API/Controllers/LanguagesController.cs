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
    public class LanguagesController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<LanguageDTO> GetLanguages([FromRoute]GetLanguageQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<LanguageDTO>> GetLanguagess()
        {
            return await Mediator.Send(new GetLanguagesQuery());
        }

        [HttpPost]
        public async Task<Unit> AddLanguages(AddLanguageCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteLanguages(DeleteLanguageCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyLanguages(ModifyLanguageCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}