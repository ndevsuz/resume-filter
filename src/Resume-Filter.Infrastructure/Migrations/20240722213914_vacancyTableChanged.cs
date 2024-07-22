using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume_Filter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class vacancyTableChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vacancies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vacancies");
        }
    }
}
