﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoSmart.Data.Migrations
{
    /// <inheritdoc />
    public partial class Topics2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Topics_Name",
                table: "Topics",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_Name",
                table: "Topics");
        }
    }
}
