

namespace SAMO.Common.Services
{
    public class UserService : IUserService
    {
        readonly AdminHttpClient _http;

        public UserService(AdminHttpClient httpClient)
        {
            _http = httpClient;
        }

        public async Task<List<GenreDTO>> GetGenresAsync<GenreDTO>()
        {
            try
            {
                using HttpResponseMessage response = await _http.Client.GetAsync("genre");
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<List<GenreDTO>>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result ?? new List<GenreDTO>();
            }
            catch
            {
                throw;
            }
        }
        public async Task<FilmDTO> GetFilmAsync(int? id)
        {
            try
            {
                if (id is null) return new FilmDTO();
                using HttpResponseMessage response = await _http.Client.GetAsync($"film/{id}");
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<FilmDTO>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result ?? new FilmDTO();
            }
            catch
            {
                throw;
            }
        }
    }
}
