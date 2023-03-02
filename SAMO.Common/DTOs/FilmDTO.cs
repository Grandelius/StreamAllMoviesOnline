

using System.ComponentModel.DataAnnotations;

namespace SAMO.Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Released { get; set; } = DateTime.Now;
        public int DirectorId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? FilmUrl { get; set; }
        public string? MarqueeImageUrl { get; set; }
        public DirectorDTO? Director { get; set; } = new();
        public List<GenreBaseDTO>? Genres { get; set; } = new();
        public List<SimilarFilmsDTO>? SimilarFilms { get; set; } = new();
    }
    public class FilmCreateDTO
    {
        public string? Title { get; set; }
        public DateTime Released { get; set; }
        public int DirectorId { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? FilmUrl { get; set; }
        public string? MarqueeImageUrl { get; set; }

    }
    public class FilmEditDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
    public class FilmBaseDTO : FilmEditDTO
    {

    }
}
