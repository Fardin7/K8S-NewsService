using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsService.Migrations
{
    public partial class ModifyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId1",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsCategoryId1",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories");

            migrationBuilder.DropColumn(
                name: "NewsCategoryId1",
                table: "News");

            migrationBuilder.RenameTable(
                name: "NewsCategories",
                newName: "NewsCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsCategory",
                table: "NewsCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategory_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategory_NewsCategoryId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsCategory",
                table: "NewsCategory");

            migrationBuilder.RenameTable(
                name: "NewsCategory",
                newName: "NewsCategories");

            migrationBuilder.AddColumn<int>(
                name: "NewsCategoryId1",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId1",
                table: "News",
                column: "NewsCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId1",
                table: "News",
                column: "NewsCategoryId1",
                principalTable: "NewsCategories",
                principalColumn: "Id");
        }
    }
}
