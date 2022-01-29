using Microsoft.EntityFrameworkCore.Migrations;

namespace RadioComponents.DataBase.Migrations
{
    public partial class jsnonbing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderInfoString",
                table: "Orders",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderInfoString",
                table: "Orders");
        }
    }
}
