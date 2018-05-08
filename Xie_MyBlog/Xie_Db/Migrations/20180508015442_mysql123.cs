﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xie_Db.Migrations
{
    public partial class mysql123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XBlogLog",
                columns: table => new
                {
                    FID = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    LogInfo = table.Column<string>(maxLength: 200, nullable: true),
                    LogSign = table.Column<int>(nullable: true),
                    Orgnazation = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Updator = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XBlogLog", x => x.FID);
                });

            migrationBuilder.CreateTable(
                name: "XBlogUser",
                columns: table => new
                {
                    FID = table.Column<string>(maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Creator = table.Column<string>(maxLength: 50, nullable: true),
                    IsAction = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Orgnazation = table.Column<string>(maxLength: 50, nullable: true),
                    PassWord = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Updator = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XBlogUser", x => x.FID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XBlogLog");

            migrationBuilder.DropTable(
                name: "XBlogUser");
        }
    }
}
