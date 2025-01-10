using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_cat03.src.data.migrations
{
    /// <inheritdoc />
    public partial class useremailpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Posts");
        }
    }
}
