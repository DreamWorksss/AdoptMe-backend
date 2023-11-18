using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptMe.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AnimalKeyDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Animals",
                newName: "Birthdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Animals",
                newName: "DateOfBirth");
        }
    }
}
