

using System.ComponentModel.DataAnnotations.Schema;

namespace SAMO.Movie.Database.Entities
{
    public class SimilarFilms : IReferenceEntity
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }
        public bool BothDirections { get; set; }
        public virtual Film Film { get; set; } = null!;
        [ForeignKey("SimilarFilmId")]
        public virtual Film Similar { get; set; } = null!;
    }
}
