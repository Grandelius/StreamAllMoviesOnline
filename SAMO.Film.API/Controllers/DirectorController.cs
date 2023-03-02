

namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;

        public DirectorController(IDbService db) => _db = db;

        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<DirectorDTO> directors =
                    await _db.GetAsync<Director, DirectorDTO>();
                return Results.Ok(directors);
            }
            catch
            {
               
            }
            return Results.BadRequest($"Couldn't get the {typeof(Director).Name} entitys.");
        }

        // GET api/<DirectorController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
            var director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id.Equals(id));
            if (director is null) return Results.NotFound();

            return Results.Ok(director);

            }
            catch
            {
              
            }
            return Results.BadRequest($"Couldn't get the {typeof(Director).Name} entity.");
        }

        // POST api/<DirectorController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Director>(director), director);
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't add the {typeof(Director).Name} entity.");
        }

        // PUT api/<DirectorController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto)
        {
          
                try
                {
                    if (dto == null) return Results.BadRequest("No entity provided");
                    if (!id.Equals(dto.Id)) return Results.BadRequest("Differing ids");

                    var exists = await _db.AnyAsync<Director>(i => i.Id.Equals(id));
                    if (!exists) return Results.NotFound("Couldnt find related entity");

                    _db.Update<Director, DirectorEditDTO>(dto.Id, dto);

                    var succes = await _db.SaveChangesAsync();

                    if (!succes) return Results.BadRequest();

                    return Results.NoContent();
                }
                catch
                {

                }
                return Results.BadRequest($"Couldn't update the {typeof(Director).Name} entity.");

        }

        // DELETE api/<DirectorController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {

                var success = await _db.DeleteAsync<Director>(id);
                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't delete the {typeof(Director).Name}entity.");
        }
    }
}
