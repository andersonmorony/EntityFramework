using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Win.Data.Migrations
{
    public partial class AddListImagemParaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ImagemPerfils",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagemPerfils_ApplicationUserId",
                table: "ImagemPerfils",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagemPerfils_AspNetUsers_ApplicationUserId",
                table: "ImagemPerfils",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagemPerfils_AspNetUsers_ApplicationUserId",
                table: "ImagemPerfils");

            migrationBuilder.DropIndex(
                name: "IX_ImagemPerfils_ApplicationUserId",
                table: "ImagemPerfils");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ImagemPerfils");

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
    }
}
