
using Microsoft.EntityFrameworkCore;

namespace SAMO.Movie.Database.Contexts
{
    public class SAMOContext : DbContext
    {
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();
        public DbSet<SimilarFilms> SimilarFilms => Set<SimilarFilms>();

        public SAMOContext(DbContextOptions<SAMOContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SimilarFilms>().HasKey(ci => new { ci.FilmId, ci.SimilarFilmId });
            builder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });

            builder.Entity<Genre>(entity => entity
            .HasMany(d => d.Films)
            .WithMany(p => p.Genres)
            .UsingEntity<FilmGenre>()
            .ToTable("FilmGenres"));                 

            builder.Entity<Film>(entity =>
            {
                entity
                .HasMany(d => d.SimilarFilms)
                .WithOne(p => p.Film)
                .HasForeignKey(d => d.FilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity
                .HasMany(d => d.Genres)
                .WithMany(p => p.Films)
                .UsingEntity<FilmGenre>()
                .ToTable("FilmGenres");
            });

            base.OnModelCreating(builder);

            //foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

        }
    }
}
