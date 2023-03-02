namespace SAMO.Common.Services
{
    public interface IUserService
    {
        Task<FilmDTO> GetFilmAsync(int? id);
        Task<List<GenreDTO>> GetGenresAsync<GenreDTO>();
    }
}