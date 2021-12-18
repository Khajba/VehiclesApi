using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkEng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarkGeo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelEng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelGeo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VinCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "dbo");
        }
    }
}
