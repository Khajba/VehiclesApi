using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesPersons_Vehicles_VehiclesId",
                table: "VehiclesPersons");

            migrationBuilder.RenameTable(
                name: "VehiclesPersons",
                newName: "VehiclesPersons",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "VehiclesId",
                schema: "dbo",
                table: "VehiclesPersons",
                newName: "PersonsId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclesPersons_VehiclesId",
                schema: "dbo",
                table: "VehiclesPersons",
                newName: "IX_VehiclesPersons_PersonsId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerType",
                schema: "dbo",
                table: "VehiclesPersons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesPersons_VehicleId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "PersonsId",
                principalSchema: "dbo",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesPersons_Vehicles_VehicleId",
                schema: "dbo",
                table: "VehiclesPersons",
                column: "VehicleId",
                principalSchema: "dbo",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesPersons_Persons_PersonsId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesPersons_Vehicles_VehicleId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesPersons_VehicleId",
                schema: "dbo",
                table: "VehiclesPersons");

            migrationBuilder.RenameTable(
                name: "VehiclesPersons",
                schema: "dbo",
                newName: "VehiclesPersons");

            migrationBuilder.RenameColumn(
                name: "PersonsId",
                table: "VehiclesPersons",
                newName: "VehiclesId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclesPersons_PersonsId",
                table: "VehiclesPersons",
                newName: "IX_VehiclesPersons_VehiclesId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerType",
                table: "VehiclesPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesPersons_Vehicles_VehiclesId",
                table: "VehiclesPersons",
                column: "VehiclesId",
                principalSchema: "dbo",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
