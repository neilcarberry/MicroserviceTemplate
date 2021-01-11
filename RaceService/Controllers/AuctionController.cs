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
    public class AuctionController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<AuctionDTO> GetAbilityModifier([FromRoute]GetAuctionModifierQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<AuctionDTO>> GetAbilityModifiers()
        {
            return await Mediator.Send(new GetAbilityModifiersQuery());
        }

        [HttpPost]
        public async Task<Unit> AddAbilityModifier(AddAuctionCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteAbilityModifier(DeleteAuctionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyAbilityModifier(ModifyAuctionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}