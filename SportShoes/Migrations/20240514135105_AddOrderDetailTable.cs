using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportShoes.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorSize_ProductColor_ProductColorID",
                table: "ColorSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorSize_Sizes_SizeID",
                table: "ColorSize");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Colors_ColorID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorSize",
                table: "ColorSize");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "ProductColors");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ColorSize",
                newName: "ColorSizes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ProductID",
                table: "ProductColors",
                newName: "IX_ProductColors_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ColorID",
                table: "ProductColors",
                newName: "IX_ProductColors_ColorID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_SupplierID",
                table: "Products",
                newName: "IX_Products_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Products",
                newName: "IX_Products_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandID",
                table: "Products",
                newName: "IX_Products_BrandID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorSize_SizeID",
                table: "ColorSizes",
                newName: "IX_ColorSizes_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorSize_ProductColorID",
                table: "ColorSizes",
                newName: "IX_ColorSizes_ProductColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors",
                column: "ProductColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorSizes",
                table: "ColorSizes",
                column: "ColorSizeID");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ColorSizeID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ColorSizes_ColorSizeID",
                        column: x => x.ColorSizeID,
                        principalTable: "ColorSizes",
                        principalColumn: "ColorSizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ColorSizeID",
                table: "OrderDetails",
                column: "ColorSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorSizes_ProductColors_ProductColorID",
                table: "ColorSizes",
                column: "ProductColorID",
                principalTable: "ProductColors",
                principalColumn: "ProductColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorSizes_Sizes_SizeID",
                table: "ColorSizes",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Colors_ColorID",
                table: "ProductColors",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_Products_ProductID",
                table: "ProductColors",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorSizes_ProductColors_ProductColorID",
                table: "ColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorSizes_Sizes_SizeID",
                table: "ColorSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Colors_ColorID",
                table: "ProductColors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_Products_ProductID",
                table: "ProductColors");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColors",
                table: "ProductColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorSizes",
                table: "ColorSizes");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                newName: "ProductColor");

            migrationBuilder.RenameTable(
                name: "ColorSizes",
                newName: "ColorSize");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierID",
                table: "Product",
                newName: "IX_Product_SupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandID",
                table: "Product",
                newName: "IX_Product_BrandID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColors_ProductID",
                table: "ProductColor",
                newName: "IX_ProductColor_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColors_ColorID",
                table: "ProductColor",
                newName: "IX_ProductColor_ColorID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorSizes_SizeID",
                table: "ColorSize",
                newName: "IX_ColorSize_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_ColorSizes_ProductColorID",
                table: "ColorSize",
                newName: "IX_ColorSize_ProductColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "SupplierID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "ProductColorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorSize",
                table: "ColorSize",
                column: "ColorSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorSize_ProductColor_ProductColorID",
                table: "ColorSize",
                column: "ProductColorID",
                principalTable: "ProductColor",
                principalColumn: "ProductColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorSize_Sizes_SizeID",
                table: "ColorSize",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandID",
                table: "Product",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierID",
                table: "Product",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Colors_ColorID",
                table: "ProductColor",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
