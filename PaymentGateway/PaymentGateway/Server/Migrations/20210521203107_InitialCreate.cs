using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateway.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    MerchantId = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.MerchantId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    MerchantId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "MerchantId", "ImageUrl", "Name" },
                values: new object[] { new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"), "/images/merch-a.jpg", "Merchant A" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "Description", "ImageUrl", "MerchantId", "Name" },
                values: new object[] { new Guid("c758e8af-0e04-4111-8fa0-4785280790cd"), 9.99m, "You want this really cool product.", "/images/prod-a.jpg", new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"), "Product A" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Amount", "Description", "ImageUrl", "MerchantId", "Name" },
                values: new object[] { new Guid("c858e8af-0e04-4111-8fa0-4785280790cd"), 19.99m, "You want this really cool product.", "/images/prod-b.jpg", new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"), "Product B" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MerchantId",
                table: "Products",
                column: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Merchants");
        }
    }
}
