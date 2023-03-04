using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagementMVC.Migrations
{
    public partial class MakeCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Code",
                table: "Subscriptions",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Code",
                table: "Subscriptions");
        }
    }
}
