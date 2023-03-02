using Microsoft.AspNetCore.Authorization;
using SAMO.Movie.Database.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDbService _db;

        public SeedController(IDbService db) => _db = db;

        // POST api/<SeedController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IResult> Seed()
        {
            try
            {
                await _db.SeedMembershipData();
                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

    }
}
