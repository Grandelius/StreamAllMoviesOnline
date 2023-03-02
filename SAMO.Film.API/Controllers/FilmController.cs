

using SAMO.Movie.Database.Entities;

namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {

        private readonly IDbService _db;

        public FilmController(IDbService db) => _db = db;

        // GET: api/<FilmController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                _db.Include<Film>();
                _db.IncludeRef<FilmGenre>();
                List<FilmDTO> films = await _db.GetAsync<Film, FilmDTO>();

                return Results.Ok(films);
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't get the {typeof(Film).Name} entitys.");
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                _db.Include<Film>();
                _db.IncludeRef<FilmGenre>();
                var film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));
                if (film is null) return Results.NotFound();

                film.Director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id.Equals(film.DirectorId));
                return Results.Ok(film);
            }
            catch
            {

            }
            return Results.NotFound($"Couldn't get the {typeof(Film).Name} entity.");
        }

        // POST api/<FilmController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Film>(film), film);

            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't add the {typeof(Film).Name}entity.");
        }

        // PUT api/<FilmController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
        {

            try
            {
                if (dto == null) return Results.BadRequest("No entity provided");
                if (!id.Equals(dto.Id)) return Results.BadRequest("Differing ids");

                var exists = await _db.AnyAsync<Director>(i => i.Id.Equals(dto.DirectorId));
                if (!exists) return Results.NotFound("Could not find related entity");

                exists = await _db.AnyAsync<Film>(c => c.Id.Equals(id));
                if (!exists) return Results.NotFound("Could not find entity");

                _db.Update<Film, FilmEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't update the {typeof(Film).Name}entity.");
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {

            try
            {
                var success = await _db.DeleteAsync<Film>(id);

                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();

            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't delete the {typeof(Film).Name}entity.");
        }
    }
}
