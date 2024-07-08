using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportShoes.Migrations
{
    /// <inheritdoc />
    public partial class AddVoucherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    MinOrderAmount = table.Column<double>(type: "float", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VoucherID = table.Column<int>(type: "int", nullable: false),
                    TransportFee = table.Column<double>(type: "float", nullable: false),
                    DeliveryStatusID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryStatuses_DeliveryStatusID",
                        column: x => x.DeliveryStatusID,
                        principalTable: "DeliveryStatuses",
                        principalColumn: "DeliveryStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Vouchers_VoucherID",
                        column: x => x.VoucherID,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AspNetUserId",
                table: "Order",
                column: "AspNetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryStatusID",
                table: "Order",
                column: "DeliveryStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VoucherID",
                table: "Order",
                column: "VoucherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
