
namespace SAMO.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimilarFilmsController : ControllerBase
    {
        private readonly IDbService _db;

        public SimilarFilmsController(IDbService db) => _db = db;

        //POST api/<FilmGenreController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] SimilarFilmsCreateDTO dto)
        {
            try
            {
                var entity = await _db.Add<SimilarFilms, SimilarFilmsCreateDTO>(dto);
                if(entity.BothDirections == true)
                {
                    var dto1 = new SimilarFilmsCreateDTO 
                    {
                        FilmId = entity.SimilarFilmId,
                        SimilarFilmId = entity.FilmId
                    };
                    var entity2 = await _db.Add<SimilarFilms, SimilarFilmsCreateDTO>(dto1);
                }
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't add the {typeof(SimilarFilms).Name} entity.");
        }

        //DELETE api/<FilmGenreController>/5
        [Route("delete")]
        [HttpPost]
        public async Task<IResult> Delete([FromBody] SimilarFilmsDeleteDTO dto)
        {
            try
            {
                if (!_db.Delete<SimilarFilms, SimilarFilmsDeleteDTO>(dto)) return Results.NotFound();
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch
            {

            }
            return Results.BadRequest($"Couldn't delete the {typeof(SimilarFilms).Name} entity.");
        }
    }
}

