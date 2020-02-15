using Microsoft.EntityFrameworkCore.Migrations;

namespace EpsilonEnterprise.Migrations
{
    public partial class Boss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_OfficeAssignment_OfficeAssignmentBossID",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentAssignment_AssignmentID",
                table: "AssignmentAssignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_OfficeAssignmentBossID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "OfficeAssignmentBossID",
                table: "Assignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeAssignmentBossID",
                table: "Assignment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentAssignment_AssignmentID",
                table: "AssignmentAssignment",
                column: "AssignmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_OfficeAssignmentBossID",
                table: "Assignment",
                column: "OfficeAssignmentBossID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_OfficeAssignment_OfficeAssignmentBossID",
                table: "Assignment",
                column: "OfficeAssignmentBossID",
                principalTable: "OfficeAssignment",
                principalColumn: "BossID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
