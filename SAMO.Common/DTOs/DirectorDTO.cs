
namespace SAMO.Common.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DirectorCreateDTO
    {
        public string Name { get; set; }
    }

    public class DirectorEditDTO : DirectorCreateDTO
    {
        public int Id { get; set; }
    }
}
