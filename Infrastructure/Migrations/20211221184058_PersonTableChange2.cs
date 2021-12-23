using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class PersonTableChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                schema: "dbo",
                table: "VehiclesPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesPersons_PersonId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "PersonId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesPersons_PersonId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "dbo",
                table: "VehiclesPersons");
        }
    }
}
