using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Win.Data.Migrations
{
    public partial class AddImagemPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagemPerfilId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImagemPerfilId",
                table: "AspNetUsers",
                column: "ImagemPerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ImagemPerfils_ImagemPerfilId",
                table: "AspNetUsers",
                column: "ImagemPerfilId",
                principalTable: "ImagemPerfils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ImagemPerfils_ImagemPerfilId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImagemPerfilId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImagemPerfilId",
                table: "AspNetUsers");
        }
    }
}
