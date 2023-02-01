using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchange.Api.Migrations
{
    public partial class useraddsmsemailpushallaw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailAllow",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PushAllow",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SmsAllow",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Id", "Amount", "CoinId", "CreatedDate", "EmailAllow", "EmailDate", "EmailMessage", "PushAllow", "PushDate", "PushMessage", "SmsAllow", "SmsDate", "SmsMessage", "Status", "UserId" },
                values: new object[,]
                {
                    { 1L, 500m, 1L, new DateTime(2023, 2, 1, 11, 31, 24, 495, DateTimeKind.Local).AddTicks(340), true, null, null, true, null, null, true, null, null, 2, 1L },
                    { 2L, 200m, 1L, new DateTime(2023, 2, 1, 11, 31, 24, 495, DateTimeKind.Local).AddTicks(740), true, null, null, true, null, null, true, null, null, 2, 1L }
                });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "EmailAllow", "PushAllow", "SmsAllow" },
                values: new object[] { new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(8950), true, true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "EmailAllow",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PushAllow",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SmsAllow",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Coins",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 19, 49, 204, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 19, 49, 205, DateTimeKind.Local).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 19, 49, 205, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 19, 49, 205, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 8, 19, 49, 205, DateTimeKind.Local).AddTicks(930));
        }
    }
}
