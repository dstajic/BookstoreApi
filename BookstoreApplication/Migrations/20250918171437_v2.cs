using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardsAuthors_Author_AuthorId",
                table: "AwardsAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardsAuthors_Award_AwardId",
                table: "AwardsAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AwardsAuthors",
                table: "AwardsAuthors");

            migrationBuilder.RenameTable(
                name: "AwardsAuthors",
                newName: "AwardAuthorBridge");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Author",
                newName: "Birthday");

            migrationBuilder.RenameIndex(
                name: "IX_AwardsAuthors_AwardId",
                table: "AwardAuthorBridge",
                newName: "IX_AwardAuthorBridge_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardsAuthors_AuthorId",
                table: "AwardAuthorBridge",
                newName: "IX_AwardAuthorBridge_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AwardAuthorBridge",
                table: "AwardAuthorBridge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardAuthorBridge_Author_AuthorId",
                table: "AwardAuthorBridge",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardAuthorBridge_Award_AwardId",
                table: "AwardAuthorBridge",
                column: "AwardId",
                principalTable: "Award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardAuthorBridge_Author_AuthorId",
                table: "AwardAuthorBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardAuthorBridge_Award_AwardId",
                table: "AwardAuthorBridge");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AwardAuthorBridge",
                table: "AwardAuthorBridge");

            migrationBuilder.RenameTable(
                name: "AwardAuthorBridge",
                newName: "AwardsAuthors");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Author",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_AwardAuthorBridge_AwardId",
                table: "AwardsAuthors",
                newName: "IX_AwardsAuthors_AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_AwardAuthorBridge_AuthorId",
                table: "AwardsAuthors",
                newName: "IX_AwardsAuthors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AwardsAuthors",
                table: "AwardsAuthors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardsAuthors_Author_AuthorId",
                table: "AwardsAuthors",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardsAuthors_Award_AwardId",
                table: "AwardsAuthors",
                column: "AwardId",
                principalTable: "Award",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
