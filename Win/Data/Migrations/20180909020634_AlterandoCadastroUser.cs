using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Win.Data.Migrations
{
    public partial class AlterandoCadastroUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Posts_PostId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Discurtidas_Posts_PostId",
                table: "Discurtidas");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Discurtidas",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Discurtidas_PostId",
                table: "Discurtidas",
                newName: "IX_Discurtidas_postId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Curtidas",
                newName: "postId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_PostId",
                table: "Curtidas",
                newName: "IX_Curtidas_postId");

            migrationBuilder.AlterColumn<int>(
                name: "postId",
                table: "Curtidas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Posts_postId",
                table: "Curtidas",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discurtidas_Posts_postId",
                table: "Discurtidas",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Posts_postId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Discurtidas_Posts_postId",
                table: "Discurtidas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Discurtidas",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Discurtidas_postId",
                table: "Discurtidas",
                newName: "IX_Discurtidas_PostId");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Curtidas",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_postId",
                table: "Curtidas",
                newName: "IX_Curtidas_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Curtidas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Posts_PostId",
                table: "Curtidas",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discurtidas_Posts_PostId",
                table: "Discurtidas",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
