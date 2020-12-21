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
    public class GenderController : BaseController
    {
        [Route("{Id}")]
        [HttpGet]
        public async Task<GenderDTO> GetGender([FromRoute]GetGenderQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet]
        public async Task<List<GenderDTO>> GetGenders()
        {
            return await Mediator.Send(new GetGendersQuery());
        }

        [HttpPost]
        public async Task<Unit> AddGender(AddGenderCommand command)
        {
            return await Mediator.Send(command);
        }

        [Route("{Id}")]
        [HttpPost]
        public async Task<Unit> DeleteGender(DeleteGenderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        public async Task<Unit> ModifyGender(ModifyGenderCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}