using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessarVideo.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoMigrationBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descritivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhoVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhoVideoZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusVideo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimProcessamento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
