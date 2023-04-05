using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class usercartrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Cart",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        E_CommerceUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        IsCompleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cart", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Cart_AspNetUsers_E_CommerceUserId",
            //            column: x => x.E_CommerceUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CartItem",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        CartId = table.Column<int>(type: "int", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        Images = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CartItem", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CartItem_Cart_CartId",
            //            column: x => x.CartId,
            //            principalTable: "Cart",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cart_E_CommerceUserId",
            //    table: "Cart",
            //    column: "E_CommerceUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CartItem_CartId",
            //    table: "CartItem",
            //    column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CartItem");

            //migrationBuilder.DropTable(
            //    name: "Cart");
        }
    }
}
