

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureAutoMapper();


builder.Services.AddCors(policy => {
policy.AddPolicy("CorsAllAccessPolicy", opt => opt
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()
 );
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SAMOContext>(
options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("SAMOConnection")));

builder.Services.AddScoped<IDbService, DbService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();
app.Run();

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Film, FilmDTO>().ReverseMap();
        cfg.CreateMap<FilmCreateDTO, Film>().ReverseMap();
        cfg.CreateMap<FilmEditDTO, Film>();
        cfg.CreateMap<Film, FilmBaseDTO>();

        cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap();
        cfg.CreateMap<DirectorCreateDTO, Director>();
        cfg.CreateMap<DirectorEditDTO, Director>();

        cfg.CreateMap<Genre, GenreDTO>()
           .ReverseMap()
           .ForMember(dest => dest.Films, src => src.Ignore());

        cfg.CreateMap<Genre, GenreBaseDTO>();

        cfg.CreateMap<GenreCreateDTO, Genre>();
        cfg.CreateMap<GenreEditDTO, Genre>();

        cfg.CreateMap<FilmGenre, FilmGenreDTO>()
        .ReverseMap();

        cfg.CreateMap<SimilarFilms, SimilarFilmsDTO>()
        .ReverseMap();
        cfg.CreateMap<SimilarFilmsDeleteDTO, SimilarFilms>();

        cfg.CreateMap<SimilarFilmsCreateDTO, SimilarFilms>();

        

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
