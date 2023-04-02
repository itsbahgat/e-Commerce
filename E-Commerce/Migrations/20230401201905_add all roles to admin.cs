using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class addallrolestoadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into AspNetUserRoles (UserId , RoleId ) select '41aa9543-c22a-450d-80e2-c11284432c07' , Id from AspNetRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetUserRoles where UserId = '41aa9543-c22a-450d-80e2-c11284432c07'");
        }
    }
}
