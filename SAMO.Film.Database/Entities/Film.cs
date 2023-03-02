
namespace SAMO.Movie.Database.Entities
{
    public class Film : IEntity
    {
        public Film()
        {
            SimilarFilms = new HashSet<SimilarFilms>();
            Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }
        [MaxLength(50), Required] public string? Title { get; set; }
        public DateTime Released { get; set; }
        public int DirectorId { get; set; }
        [MaxLength(1024)] public string? Description { get; set; }
        [MaxLength(1024)] public string? ImageUrl { get; set; }
        [MaxLength(1024)] public string? MarqueeImageUrl { get; set; }
        [MaxLength(1024)] public string? FilmUrl { get; set; }

        public virtual Director? Director { get; set; } = null!;
        public virtual ICollection<Genre>? Genres { get; set; }
        public virtual ICollection<SimilarFilms>? SimilarFilms { get; set; }
    }
}
