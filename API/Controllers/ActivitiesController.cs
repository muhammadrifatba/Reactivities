using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {
        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await context.Activities.ToListAsync();
        }  

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            
            var activity = await context.Activities.FindAsync(id);
            
            if (activity == null) return NotFound();
            
            return activity;
        }
    }
}
