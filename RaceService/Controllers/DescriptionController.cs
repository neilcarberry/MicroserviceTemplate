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
    public class DescriptionController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<List<DescriptionDTO>> GetDescription([FromRoute]GetDescriptionQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<Unit> AddDescription(AddDescriptionCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteDescription(DeleteDescriptionCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyDescription(ModifyDescriptionCommand command)
        {
            return await Mediator.Send(command);

        }
    }
}