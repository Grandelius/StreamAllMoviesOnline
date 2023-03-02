
namespace SAMO.Movie.Database.Entities
{
    public class Genre : IEntity
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }
        public int Id { get; set; }
        [MaxLength(80), Required] public string Name { get; set; }
        public virtual ICollection<Film>? Films { get; set; }
    }
}
