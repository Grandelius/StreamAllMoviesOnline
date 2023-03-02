

namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IDbService _db;

        public GenreController(IDbService db) => _db = db;

        // GET: api/<GenreController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<Genre>();
                _db.IncludeRef<FilmGenre>();
                List<GenreDTO> genres = await _db.GetAsync<Genre, GenreDTO>();

                return Results.Ok(genres);
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't get the {typeof(Genre).Name} entitys.");
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Genre>();
                _db.IncludeRef<FilmGenre>();
                var genre = await _db.SingleAsync<Genre, GenreDTO>(c => c.Id.Equals(id));
                if (genre is null) return Results.NotFound();

                return Results.Ok(genre);

            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't get the {typeof(Genre).Name} entity.");
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var genre = await _db.AddAsync<Genre, GenreCreateDTO>(dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Genre>(genre), genre);
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't add the {typeof(Genre).Name} entity.");
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest("No entity provided");
                if (!id.Equals(dto.Id)) return Results.BadRequest("Differing ids");

                var exists = await _db.AnyAsync<Genre>(i => i.Id.Equals(id));
                if (!exists) return Results.NotFound("Couldnt find related entity");

                _db.Update<Genre, GenreEditDTO>(dto.Id, dto);

                var succes = await _db.SaveChangesAsync();

                if (!succes) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't update the {typeof(Genre).Name} entity.");

        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {

            try
            {

                var success = await _db.DeleteAsync<Genre>(id);
                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't delete the {typeof(Genre).Name} entity.");
        }
    }
}
