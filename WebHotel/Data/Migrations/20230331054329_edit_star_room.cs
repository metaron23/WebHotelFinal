using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit_star_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "StarAmount",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StarValue",
                table: "Room",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarAmount",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "StarValue",
                table: "Room");

            migrationBuilder.AddColumn<float>(
                name: "Star",
                table: "Room",
                type: "real",
                nullable: true);
        }
    }
}
