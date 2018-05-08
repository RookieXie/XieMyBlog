using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xie_Db.Migrations
{
    public partial class mysql654 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XBlogTitleType",
                columns: table => new
                {
                    FID = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    Orgnazation = table.Column<string>(maxLength: 50, nullable: true),
                    TypeInt = table.Column<int>(nullable: true),
                    TypeName = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Updator = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XBlogTitleType", x => x.FID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XBlogTitleType");
        }
    }
}
