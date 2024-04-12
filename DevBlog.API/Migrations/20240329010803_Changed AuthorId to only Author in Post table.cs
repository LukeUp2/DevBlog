using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlog.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAuthorIdtoonlyAuthorinPosttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_AuthorIdId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "AuthorIdId",
                table: "posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_AuthorIdId",
                table: "posts",
                newName: "IX_posts_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_AuthorId",
                table: "posts",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_AuthorId",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "posts",
                newName: "AuthorIdId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_AuthorId",
                table: "posts",
                newName: "IX_posts_AuthorIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_AuthorIdId",
                table: "posts",
                column: "AuthorIdId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
