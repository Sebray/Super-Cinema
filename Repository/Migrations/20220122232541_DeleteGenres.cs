using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class DeleteGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenresInFilms");

            migrationBuilder.DropColumn(
                name: "Commentary",
                table: "PurchasedFilms");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "PurchasedFilms");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Films",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Films");

            migrationBuilder.AddColumn<string>(
                name: "Commentary",
                table: "PurchasedFilms",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Score",
                table: "PurchasedFilms",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Films",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "GenresInFilms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FilmId = table.Column<int>(type: "integer", nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresInFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenresInFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenresInFilms_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenresInFilms_FilmId",
                table: "GenresInFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresInFilms_GenreId",
                table: "GenresInFilms",
                column: "GenreId");
        }
    }
}
