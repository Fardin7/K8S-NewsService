using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsService.Migrations
{
    public partial class DBInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    NewsCategoryId = table.Column<int>(type: "int", nullable: false),
                    NewsCategoryId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_NewsCategoryId",
                        column: x => x.NewsCategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_NewsCategories_NewsCategoryId1",
                        column: x => x.NewsCategoryId1,
                        principalTable: "NewsCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "this category is about Sport", "Sport" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Body", "Description", "NewsCategoryId", "NewsCategoryId1", "Title" },
                values: new object[] { 1, "Sport news Body", "Sport news Description", 1, null, "Sport news title" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Body", "Description", "NewsCategoryId", "NewsCategoryId1", "Title" },
                values: new object[] { 2, "Sport2 news Body", "Sport2 news Description", 1, null, "Sport2 news title" });

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId1",
                table: "News",
                column: "NewsCategoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsCategories");
        }
    }
}
