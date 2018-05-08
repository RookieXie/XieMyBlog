using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xie_Db.Migrations
{
    public partial class mysql132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XBlogArticle",
                columns: table => new
                {
                    FID = table.Column<string>(maxLength: 50, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    Orgnazation = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    TitleType = table.Column<int>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Updator = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XBlogArticle", x => x.FID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XBlogArticle");
        }
    }
}
