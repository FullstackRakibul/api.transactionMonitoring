using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace v1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasicMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchantBasicDetails_AspNetUsers_MerchantUserId",
                table: "MerchantBasicDetails");

            migrationBuilder.DropIndex(
                name: "IX_MerchantBasicDetails_MerchantUserId",
                table: "MerchantBasicDetails");

            migrationBuilder.AlterColumn<string>(
                name: "MerchantUserId",
                table: "MerchantBasicDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MerchantUserId",
                table: "MerchantBasicDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBasicDetails_MerchantUserId",
                table: "MerchantBasicDetails",
                column: "MerchantUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantBasicDetails_AspNetUsers_MerchantUserId",
                table: "MerchantBasicDetails",
                column: "MerchantUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
