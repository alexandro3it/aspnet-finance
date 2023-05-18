using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPFinance.Migrations
{
    public partial class AddInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreditDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Descripton = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DebtDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debits_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cliente 1" },
                    { 2, "Cliente 2" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Forncedor 1" },
                    { 2, "Forncedor 2" },
                    { 3, "Forncedor 2" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "Id", "CreditDay", "CustomerId", "Date", "Descripton", "Title", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 18, 13, 0, 0, 0, DateTimeKind.Local).AddTicks(1451), 1, new DateTime(2023, 5, 18, 13, 45, 0, 0, DateTimeKind.Local).AddTicks(1450), "Samsung modelo S1", "Samsung S1", 5000.99m },
                    { 2, new DateTime(2023, 5, 18, 13, 5, 0, 0, DateTimeKind.Local).AddTicks(1453), 1, new DateTime(2023, 5, 18, 13, 45, 0, 0, DateTimeKind.Local).AddTicks(1452), "Motolora modelo M1", "Motolora M1", 4000.99m },
                    { 3, new DateTime(2023, 5, 18, 13, 10, 0, 0, DateTimeKind.Local).AddTicks(1455), 2, new DateTime(2023, 5, 18, 13, 45, 0, 0, DateTimeKind.Local).AddTicks(1454), "LG modelo LG1", "LG LG1", 3000.99m },
                    { 4, new DateTime(2023, 5, 18, 13, 15, 0, 0, DateTimeKind.Local).AddTicks(1456), 2, new DateTime(2023, 5, 18, 13, 45, 0, 0, DateTimeKind.Local).AddTicks(1456), "Motolora modelo M2", "Motolora M2", 3509.99m }
                });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "Date", "DebtDay", "Descripton", "SupplierId", "Title", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 18, 13, 45, 00, 0, DateTimeKind.Local).AddTicks(1415), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Local).AddTicks(1425), "Campanhia de Distribuição de Energia", 1, "Energia", 500.99m },
                    { 2, new DateTime(2023, 5, 18, 13, 45, 00, 0, DateTimeKind.Local).AddTicks(1433), new DateTime(2023, 5, 17, 0, 5, 0, 0, DateTimeKind.Local).AddTicks(1434), "Campanhia de Tratamento de Agua e esgoto", 2, "Água e esgoto", 400.99m },
                    { 3, new DateTime(2023, 5, 18, 13, 45, 00, 0, DateTimeKind.Local).AddTicks(1435), new DateTime(2023, 5, 17, 0, 10, 0, 0, DateTimeKind.Local).AddTicks(1436), "Campanhia de Comunicações", 3, "Internet", 300.99m },
                    { 4, new DateTime(2023, 5, 18, 13, 45, 00, 0, DateTimeKind.Local).AddTicks(1437), new DateTime(2023, 5, 17, 0, 15, 0, 0, DateTimeKind.Local).AddTicks(1438), "Campanhia de Comunicações", 3, "Telefone", 350.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CustomerId",
                table: "Credits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_SupplierId",
                table: "Debits",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Debits");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
