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
    public class NamesController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<NamesDTO> GetNamess([FromRoute]GetNamesQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<NamesDTO>> GetNamesss()
        {
            return await Mediator.Send(new GetNamessQuery());
        }

        [HttpPost]
        public async Task<Unit> AddNamess(AddNamesCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteNamess(DeleteNamesCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyNamess(ModifyNamesCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}