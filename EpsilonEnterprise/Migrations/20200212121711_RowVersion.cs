using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpsilonEnterprise.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Assignments_AssignmentID",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Boss_BossID",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Boss_AdministratorID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Assignments_AssignmentID",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Department_AdministratorID",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_BossID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "AdministratorID",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "BossID",
                table: "Assignment");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Department",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Assignment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Assignment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeAssignmentBossID",
                table: "Assignment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Assignment",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "AssignmentID");

            migrationBuilder.CreateTable(
                name: "AssignmentAssignment",
                columns: table => new
                {
                    BossID = table.Column<int>(nullable: false),
                    AssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentAssignment", x => new { x.AssignmentID, x.BossID });
                    table.ForeignKey(
                        name: "FK_AssignmentAssignment_Assignment_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentAssignment_Boss_BossID",
                        column: x => x.BossID,
                        principalTable: "Boss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_BossID",
                table: "Department",
                column: "BossID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_DepartmentID",
                table: "Assignment",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_OfficeAssignmentBossID",
                table: "Assignment",
                column: "OfficeAssignmentBossID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentAssignment_AssignmentID",
                table: "AssignmentAssignment",
                column: "AssignmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentAssignment_BossID",
                table: "AssignmentAssignment",
                column: "BossID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Department_DepartmentID",
                table: "Assignment",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_OfficeAssignment_OfficeAssignmentBossID",
                table: "Assignment",
                column: "OfficeAssignmentBossID",
                principalTable: "OfficeAssignment",
                principalColumn: "BossID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Boss_BossID",
                table: "Department",
                column: "BossID",
                principalTable: "Boss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Assignment_AssignmentID",
                table: "Enrollment",
                column: "AssignmentID",
                principalTable: "Assignment",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Department_DepartmentID",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_OfficeAssignment_OfficeAssignmentBossID",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Boss_BossID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Assignment_AssignmentID",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "AssignmentAssignment");

            migrationBuilder.DropIndex(
                name: "IX_Department_BossID",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_DepartmentID",
                table: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_Assignment_OfficeAssignmentBossID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "OfficeAssignmentBossID",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Assignment");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorID",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BossID",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                columns: new[] { "AssignmentID", "BossID" });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentID1 = table.Column<int>(type: "int", nullable: true),
                    BossID = table.Column<int>(type: "int", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_Assignments_AssignmentID1",
                        column: x => x.AssignmentID1,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Boss_BossID",
                        column: x => x.BossID,
                        principalTable: "Boss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_AdministratorID",
                table: "Department",
                column: "AdministratorID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_BossID",
                table: "Assignment",
                column: "BossID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentID1",
                table: "Assignments",
                column: "AssignmentID1");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_BossID",
                table: "Assignments",
                column: "BossID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_DepartmentID",
                table: "Assignments",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Assignments_AssignmentID",
                table: "Assignment",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Boss_BossID",
                table: "Assignment",
                column: "BossID",
                principalTable: "Boss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Boss_AdministratorID",
                table: "Department",
                column: "AdministratorID",
                principalTable: "Boss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Assignments_AssignmentID",
                table: "Enrollment",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
