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
        public async Task<AuctionDTO> GetAuction([FromRoute] GetAuctionQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<Unit> AddAuction(AddAuctionCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteAuction(DeleteAuctionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyAuction(ModifyAuctionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}