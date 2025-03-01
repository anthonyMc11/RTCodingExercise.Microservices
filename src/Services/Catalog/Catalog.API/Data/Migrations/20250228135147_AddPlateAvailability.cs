#nullable disable

namespace Catalog.API.Migrations;

public partial class AddPlateAvailability : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Availability",
            table: "Plates",
            type: "int",
            nullable: false,
            defaultValue: Availability.Available);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Availability",
            table: "Plates");
    }
}
