using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPortal_Hospital.Migrations
{
    /// <inheritdoc />
    public partial class changedsomething : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Hospitals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
