using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAppAPI.Data;
using SocialAppAPI.Entities;

namespace SocialAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public UsersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await dataContext.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await dataContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
