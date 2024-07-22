using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume_Filter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecruiterIdPropertyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HR_Id",
                table: "Vacancies",
                newName: "RecruiterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecruiterId",
                table: "Vacancies",
                newName: "HR_Id");
        }
    }
}
