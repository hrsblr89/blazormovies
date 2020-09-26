using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp3.Server.Migrations
{
    public partial class RemoveExtraColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId",
                table: "MoviesGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesGenres",
                table: "MoviesGenres");

            migrationBuilder.DropColumn(
                name: "GenresID",
                table: "MoviesGenres");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "MoviesGenres",
                newName: "GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesGenres_GenreId",
                table: "MoviesGenres",
                newName: "IX_MoviesGenres_GenreID");

            migrationBuilder.AlterColumn<int>(
                name: "GenreID",
                table: "MoviesGenres",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesGenres",
                table: "MoviesGenres",
                columns: new[] { "MovieId", "GenreID" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesGenres_Genres_GenreID",
                table: "MoviesGenres",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesGenres_Genres_GenreID",
                table: "MoviesGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesGenres",
                table: "MoviesGenres");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "MoviesGenres",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesGenres_GenreID",
                table: "MoviesGenres",
                newName: "IX_MoviesGenres_GenreId");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "MoviesGenres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GenresID",
                table: "MoviesGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesGenres",
                table: "MoviesGenres",
                columns: new[] { "MovieId", "GenresID" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesGenres_Genres_GenreId",
                table: "MoviesGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
