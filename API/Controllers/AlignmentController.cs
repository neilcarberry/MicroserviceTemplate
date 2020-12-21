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
    public class AlignmentController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<AlignmentDTO> GetAlignment([FromRoute]GetAlignmentQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<AlignmentDTO>> GetAlignments()
        {
            return await Mediator.Send(new GetAlignmentsQuery());
        }

        [HttpPost]
        public async Task<Unit> AddAlignment(AddAlignmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteAlignment(DeleteAlignmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyAlignment(ModifyAlignmentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}