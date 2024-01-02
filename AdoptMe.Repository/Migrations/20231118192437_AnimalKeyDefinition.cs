using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptMe.Repository.Migrations
{
    /// <inheritdoc />
    public partial class PetKeyDefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Pets",
                newName: "Birthdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Pets",
                newName: "DateOfBirth");
        }
    }
}
