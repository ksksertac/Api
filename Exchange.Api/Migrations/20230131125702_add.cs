using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchange.Api.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinInstructionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxInstructionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartOfInstructionDay = table.Column<int>(type: "int", nullable: false),
                    EndOfInstructionDay = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SmsAllow = table.Column<bool>(type: "bit", nullable: true),
                    SmsMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmsDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailAllow = table.Column<bool>(type: "bit", nullable: true),
                    EmailMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PushAllow = table.Column<bool>(type: "bit", nullable: true),
                    PushMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructions_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "Price", "ShortName" },
                values: new object[] { 1L, new DateTime(2023, 1, 31, 15, 57, 2, 264, DateTimeKind.Local).AddTicks(9060), null, true, "Bitcoin", 500000m, "btc" });

            migrationBuilder.InsertData(
                table: "NotificationTemplates",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name", "TemplateText", "TemplateTitle", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 31, 15, 57, 2, 265, DateTimeKind.Local).AddTicks(2590), "Talimat işlemi tamamlanınca gönderilir", true, "InstructionCompleteEmail", "Sayın {0} <br> {1} nolu talimatınız alınmıştır.", "Talimatınız alındı", 1 },
                    { 2, new DateTime(2023, 1, 31, 15, 57, 2, 265, DateTimeKind.Local).AddTicks(2650), "Talimat işlemi tamamlanınca gönderilir", true, "InstructionCompleteSms", "Sayın {0} <br> {1} nolu talimatınız alınmıştır.", "Talimatınız alındı", 2 },
                    { 3, new DateTime(2023, 1, 31, 15, 57, 2, 265, DateTimeKind.Local).AddTicks(2660), "Talimat işlemi tamamlanınca gönderilir", true, "InstructionCompletePush", "Sayın {0} <br> {1} nolu talimatınız alınmıştır.", "Talimatınız alındı", 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DeviceId", "Email", "EndOfInstructionDay", "IsActive", "MaxInstructionAmount", "MinInstructionAmount", "NameSurname", "Password", "Phone", "StartOfInstructionDay" },
                values: new object[] { 1L, new DateTime(2023, 1, 31, 15, 57, 2, 265, DateTimeKind.Local).AddTicks(1820), null, "26FB1AB0CA8483866", "ksksertac@gmail.com", 28, true, 20000m, 100m, "Test User", "26FB1AB0CA8483866F03CA66E2018B0685F3E1E84CACA77B3F5643AE799D9EB4", "5079144614", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_CoinId",
                table: "Instructions",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_UserIdId",
                table: "Instructions",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
