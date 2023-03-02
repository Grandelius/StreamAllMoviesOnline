

namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmGenreController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmGenreController(IDbService db) => _db = db;

        //POST api/<FilmGenreController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
        {
            try
            {
                var entity = await _db.Add<FilmGenre, FilmGenreDTO>(dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch
            {
              
            }
            return Results.BadRequest($"Couldn't add the {typeof(FilmGenre).Name}entity.");
        }

      
        [Route("delete")]
        [HttpPost]
        public async Task<IResult> Delete([FromBody]FilmGenreDTO dto)
        {
            try
            {
                if (!_db.Delete<FilmGenre, FilmGenreDTO>(dto)) return Results.NotFound();
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch
            {
              
            }
            return Results.BadRequest($"Couldn't delete the {typeof(Film).Name}entity.");
        }
    }
}
