using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class addadminuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //add admin static 
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [FirstName], [LastName]) VALUES (N'41aa9543-c22a-450d-80e2-c11284432c07', N'wgugnkjl@bugfoo.com', N'WGUGNKJL@BUGFOO.COM', N'wgugnkjl@bugfoo.com', N'WGUGNKJL@BUGFOO.COM', 1, N'AQAAAAIAAYagAAAAEIKuzM05uBZ/hOY7Zg/EnHly8xxsSBzoqsCUHoPHp57pvK9is5xJ9tz8jWN/kwRLpQ==', N'4VGVLSFRJ55ZOCDYOYBU72ZMJNJSHLMV', N'2c702f7e-117a-4290-a1ff-895e295f3b38', N'01003333333', 0, 0, NULL, 1, 0, N'el kafr', N'admin', N'admin')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = '41aa9543-c22a-450d-80e2-c11284432c07'");
        }
    }
}
