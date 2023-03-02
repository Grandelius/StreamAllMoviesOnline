

namespace SAMO.Common.DTOs
{
    public class SimilarFilmsDTO
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }
        public bool BothDirections { get; set; }

        public FilmBaseDTO Similar { get; set; }
    }
    public class SimilarFilmsDeleteDTO
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }
    }
    public class SimilarFilmsCreateDTO : SimilarFilmsDeleteDTO
    {
        public bool BothDirections { get; set; }
    }

  
}
