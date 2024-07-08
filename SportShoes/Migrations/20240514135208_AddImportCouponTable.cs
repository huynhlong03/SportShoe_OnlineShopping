using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportShoes.Migrations
{
    /// <inheritdoc />
    public partial class AddImportCouponTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportCoupons",
                columns: table => new
                {
                    ImportCouponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportCoupons", x => x.ImportCouponID);
                    table.ForeignKey(
                        name: "FK_ImportCoupons_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportCoupons_SupplierID",
                table: "ImportCoupons",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportCoupons");
        }
    }
}
