

namespace SAMO.Movie.Database.Extensions
{
    public static class SAMOContextExtensions
    {
        public static async Task SeedMembershipData(this IDbService service)
        {
            try
            {
                //ADD DIRECTORS
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {
                    Name = "Peter Jackson"
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {
                    Name = "Steven Spielberg"
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {
                    Name = "Michael Bay"
                });
                await service.AddAsync<Director, DirectorDTO>(new DirectorDTO
                {
                    Name = "David Yates"
                });
                await service.SaveChangesAsync();

                //ADD GENRES
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {
                    Name = "Action"
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {
                    Name = "Sci-Fi"
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {
                    Name = "Fantasy"
                });
                await service.AddAsync<Genre, GenreDTO>(new GenreDTO
                {
                    Name = "Drama"
                });
                await service.SaveChangesAsync();

                var director1 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Peter Jackson"));
                var director2 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Steven Spielberg"));
                var director3 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("Michael Bay"));
                var director4 = await service.SingleAsync<Director, DirectorDTO>(c => c.Name.Equals("David Yates"));

                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {
                    Title = "Hobbit: En oväntad resa",
                    Description = "Hoben Bilbo är på väg österut tillsammans med 13 dvärgar och trollkarlen Gandalf." +
                    " Deras mål är att återta en stulen skatt vaktad av den fasansfulla draken Smaug." +
                    " Under resan träffar Bilbo varelsen som kommer att förändra hans liv för alltid, Gollum.",
                    Released = new DateTime(2012, 11, 28),
                    DirectorId = director1.Id,
                    ImageUrl = "Imagehobbit",
                    FilmUrl = "hobbitlink"

                });
                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {
                    Title = "Hobbit: Smaugs ödemark",
                    Description = "Bilbo Baggers fortsätter tillsammans med Gandalf och de tretton dvärgarna på uppdraget att kräva tillbaka dvärgarnas förlorade rike, Erebor." +
                    " Ett äventyr som bland annat tar dem till Smaugs ödemark.",
                    Released = new DateTime(2013, 12, 11),
                    DirectorId = director1.Id,
                    ImageUrl = "Imagehobbit2",
                    FilmUrl = "hobbitlink2"

                });
                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {
                    Title = "Jurassic Park",
                    Description = "Den excentriske mångmiljonären John Hammond bjuder in två dinosaurieexperter till sin nöjespark på en ö utanför Costa Rica." +
                    " Hammond har lyckats skapa levande dinosaurier genom att klona DNA från förhistoriska insekter.",
                    Released = new DateTime(1993, 9, 3),
                    DirectorId = director2.Id,
                    ImageUrl = "ImageJurassic",
                    FilmUrl = "Jurassiclink"

                });
                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {
                    Title = "Bumblebee",
                    Description = "Året är 1987 och Bumblebee, som är på flykt, tar skydd på ett skrotupplag i en liten strandstad i Kalifornien." +
                    " Där hittas han av Charlie, som snart ska fylla 18 och försöker hitta sin plats i världen.",
                    Released = new DateTime(2018, 12, 25),
                    DirectorId = director3.Id,
                    ImageUrl = "ImageBumblebee",
                    FilmUrl = "Bumblebeelink"

                });
                await service.AddAsync<Film, FilmDTO>(new FilmDTO
                {
                    Title = "Harry Potter och Fenixorden",
                    Description = "Den nya läraren i försvar mot svartkonster har vissa byråkratiska metoder som gör Hogwarts försvarslöst mot en ondskefull sammansvärjning." +
                    " Harry börjar då lära en grupp elever hur man försvarar sig mot svartkonster.",
                    Released = new DateTime(2007, 7, 13),
                    DirectorId = director4.Id,
                    ImageUrl = "ImageHarry",
                    FilmUrl = "Harrylink"

                });
                await service.SaveChangesAsync();

                var film1 = await service.SingleAsync<Film, FilmDTO>(c => c.Title.Equals("Hobbit: En oväntad resa"));
                var film2 = await service.SingleAsync<Film, FilmDTO>(c => c.Title.Equals("Hobbit: Smaugs ödemark"));
                var film3 = await service.SingleAsync<Film, FilmDTO>(c => c.Title.Equals("Jurassic Park"));
                var film4 = await service.SingleAsync<Film, FilmDTO>(c => c.Title.Equals("Bumblebee"));
                var film5 = await service.SingleAsync<Film, FilmDTO>(c => c.Title.Equals("Harry Potter och Fenixorden"));

                var genre1 = await service.SingleAsync<Genre, GenreDTO>(c => c.Name.Equals("Action"));
                var genre2 = await service.SingleAsync<Genre, GenreDTO>(c => c.Name.Equals("Sci-Fi"));
                var genre3 = await service.SingleAsync<Genre, GenreDTO>(c => c.Name.Equals("Fantasy"));
                var genre4 = await service.SingleAsync<Genre, GenreDTO>(c => c.Name.Equals("Drama"));

                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film1.Id,
                    GenreId = genre3.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film1.Id,
                    GenreId = genre4.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film2.Id,
                    GenreId = genre3.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film2.Id,
                    GenreId = genre4.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film3.Id,
                    GenreId = genre1.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film4.Id,
                    GenreId = genre1.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film4.Id,
                    GenreId = genre2.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film5.Id,
                    GenreId = genre3.Id

                });
                await service.AddAsync<FilmGenre, FilmGenreDTO>(new FilmGenreDTO
                {
                    FilmId = film5.Id,
                    GenreId = genre4.Id

                });
                await service.SaveChangesAsync();

                await service.AddAsync<SimilarFilms, SimilarFilmsDTO>(new SimilarFilmsDTO
                {
                    FilmId = film1.Id,
                    SimilarFilmId = film2.Id,
                    BothDirections = true

                }) ;
                await service.SaveChangesAsync();

            }

            catch
            {
                throw;
            }
        }
    }
}
