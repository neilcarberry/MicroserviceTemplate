using Application.Handlers.Commands;
using Application.Handlers.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RaceController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<BaseDetailsDTO> GetRace([FromRoute]GetRaceQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<BaseDetailsDTO>> GetRaces() 
        {
            return await Mediator.Send(new GetRacesQuery());
        }

        [HttpPost]
        public async Task<Unit> AddRace(AddRaceCommand command) 
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteRace(DeleteRaceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyRace(ModifyRaceCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}