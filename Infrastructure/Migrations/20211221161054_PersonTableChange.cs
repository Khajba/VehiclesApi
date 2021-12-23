using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PersonTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesPersons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropColumn(
                name: "PersonsId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.RenameColumn(
                name: "PersonalId",
                schema: "dbo",
                table: "Persons",
                newName: "PersonNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonNumber",
                schema: "dbo",
                table: "Persons",
                newName: "PersonalId");

            migrationBuilder.AddColumn<int>(
                name: "PersonsId",
                schema: "dbo",
                table: "VehiclesPersons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesPersons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "PersonsId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
