

namespace SAMO.Common.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<FilmDTO>? Films { get; set; } 
    }
    public class GenreCreateDTO
    {
        public string? Name { get; set; }
    }
    public class GenreEditDTO : GenreCreateDTO
    {
        public int Id { get; set; }
    }

    public class GenreBaseDTO : GenreEditDTO
    {

    }
}
