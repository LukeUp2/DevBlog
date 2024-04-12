using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlog.API.Migrations
{
    /// <inheritdoc />
    public partial class ContentrowinsertedinPostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "posts");
        }
    }
}
