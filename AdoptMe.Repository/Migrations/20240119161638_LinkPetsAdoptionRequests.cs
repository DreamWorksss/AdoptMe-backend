using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptMe.Repository.Migrations
{
    /// <inheritdoc />
    public partial class LinkPetsAdoptionRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_Pets_PetId",
                table: "AdoptionRequests",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_Pets_PetId",
                table: "AdoptionRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_PetId",
                table: "AdoptionRequests");
        }
    }
}
