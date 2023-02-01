using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchange.Api.Migrations
{
    public partial class editforeingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Users_UserIdId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_UserIdId",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Instructions");

            migrationBuilder.UpdateData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 27, 10, 202, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 27, 10, 202, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 27, 10, 202, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 27, 10, 202, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 27, 10, 202, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_UserId",
                table: "Instructions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Users_UserId",
                table: "Instructions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Users_UserId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_UserId",
                table: "Instructions");

            migrationBuilder.AddColumn<long>(
                name: "UserIdId",
                table: "Instructions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 21, 20, 766, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 21, 20, 766, DateTimeKind.Local).AddTicks(5700));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 21, 20, 766, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 21, 20, 766, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 31, 16, 21, 20, 766, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_UserIdId",
                table: "Instructions",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Users_UserIdId",
                table: "Instructions",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
