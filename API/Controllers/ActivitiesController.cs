using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController( IMediator mediator) : BaseApiController
    {
        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await mediator.Send(new GetActivityList.Query());
        }  

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            
           return await mediator.Send(new GetActivityDetails.Query{ Id = id });
        }
    }
}
