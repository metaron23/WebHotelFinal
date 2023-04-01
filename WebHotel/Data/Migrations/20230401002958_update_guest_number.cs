using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_guest_number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GuestNumber",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "GuestNumber",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((1))");
        }
    }
}
