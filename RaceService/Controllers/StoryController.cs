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
    public class StoryController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<List<StoryDTO>> GetStorys()
        {
            return await Mediator.Send(new GetStoryQuery());
        }

        [HttpPost]
        public async Task<Unit> AddStory(AddStoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteStory(DeleteStoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyStory(ModifyStoryCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}