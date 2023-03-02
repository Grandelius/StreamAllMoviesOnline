using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAMO.Movie.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSAMOCOntext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_SimilarFilmId",
                table: "SimilarFilms");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_SimilarFilmId",
                table: "SimilarFilms",
                column: "SimilarFilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_SimilarFilmId",
                table: "SimilarFilms");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_SimilarFilmId",
                table: "SimilarFilms",
                column: "SimilarFilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
