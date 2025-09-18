using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "Fiction writer from USA", new DateTime(1975, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe" },
                    { 2, "Science fiction author", new DateTime(1980, 8, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Smith" },
                    { 3, "Children's books author", new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Alice Johnson" },
                    { 4, "Historical novels writer", new DateTime(1965, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Robert Brown" },
                    { 5, "Mystery novels author", new DateTime(1985, 7, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Emily Davis" }
                });

            migrationBuilder.InsertData(
                table: "Award",
                columns: new[] { "Id", "Description", "Name", "StartYear" },
                values: new object[,]
                {
                    { 1, "Award for best fiction book", "Best Fiction", 2000 },
                    { 2, "Award for outstanding science fiction", "Sci-Fi Excellence", 2005 },
                    { 3, "Award for children's books", "Children's Choice", 2010 },
                    { 4, "Award for mystery novels", "Mystery Master", 2015 }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "123 Main St, NY", "Sunshine Books", "http://sunshinebooks.com" },
                    { 2, "456 Oak Ave, LA", "Moonlight Press", "http://moonlightpress.com" },
                    { 3, "789 Pine Rd, TX", "Star Publishers", "http://starpublishers.com" }
                });

            migrationBuilder.InsertData(
                table: "AwardAuthorBridge",
                columns: new[] { "Id", "AuthorId", "AwardId", "awardYear" },
                values: new object[,]
                {
                    { 1, 1, 1, 2001 },
                    { 2, 2, 2, 2006 },
                    { 3, 3, 3, 2011 },
                    { 4, 4, 1, 2000 },
                    { 5, 5, 4, 2016 },
                    { 6, 1, 2, 2005 },
                    { 7, 2, 1, 2007 },
                    { 8, 3, 3, 2012 },
                    { 9, 4, 4, 2017 },
                    { 10, 5, 2, 2018 },
                    { 11, 1, 3, 2013 },
                    { 12, 2, 4, 2019 },
                    { 13, 3, 1, 2014 },
                    { 14, 4, 2, 2015 },
                    { 15, 5, 3, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "978-0-1111-1111-1", 320, new DateTime(2001, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), 1, "The Dawn" },
                    { 2, 2, "978-0-1111-1111-2", 280, new DateTime(2005, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Space Odyssey" },
                    { 3, 3, "978-0-1111-1111-3", 150, new DateTime(2010, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Magic Tales" },
                    { 4, 4, "978-0-1111-1111-4", 400, new DateTime(1999, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), 3, "History of Rome" },
                    { 5, 5, "978-0-1111-1111-5", 250, new DateTime(2015, 9, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Mystery Manor" },
                    { 6, 1, "978-0-1111-1111-6", 300, new DateTime(2008, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Ocean Secrets" },
                    { 7, 2, "978-0-1111-1111-7", 360, new DateTime(2012, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Future Worlds" },
                    { 8, 3, "978-0-1111-1111-8", 200, new DateTime(2018, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Fairy Land" },
                    { 9, 4, "978-0-1111-1111-9", 420, new DateTime(2000, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Ancient Empires" },
                    { 10, 5, "978-0-1111-1111-10", 290, new DateTime(2016, 6, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Detective Stories" },
                    { 11, 1, "978-0-1111-1111-11", 310, new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Lost Kingdom" },
                    { 12, 2, "978-0-1111-1111-12", 270, new DateTime(2014, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Starlight Adventures" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AwardAuthorBridge",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Award",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Award",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Award",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Award",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
