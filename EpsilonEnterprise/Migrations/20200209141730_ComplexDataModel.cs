using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpsilonEnterprise.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentID",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID1",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BossID",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boss",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boss", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    BossID = table.Column<int>(nullable: false),
                    AssignmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => new { x.AssignmentID, x.BossID });
                    table.ForeignKey(
                        name: "FK_Assignment_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Boss_BossID",
                        column: x => x.BossID,
                        principalTable: "Boss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    BossID = table.Column<int>(nullable: true),
                    AdministratorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Department_Boss_AdministratorID",
                        column: x => x.AdministratorID,
                        principalTable: "Boss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignment",
                columns: table => new
                {
                    BossID = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignment", x => x.BossID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignment_Boss_BossID",
                        column: x => x.BossID,
                        principalTable: "Boss",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_BossID",
                table: "Assignment",
                column: "BossID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_AdministratorID",
                table: "Department",
                column: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Assignments_AssignmentID1",
                table: "Assignments",
                column: "AssignmentID1",
                principalTable: "Assignments",
                principalColumn: "AssignmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Boss_BossID",
                table: "Assignments",
                column: "BossID",
                principalTable: "Boss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Department_DepartmentID",
                table: "Assignments",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Assignments_AssignmentID1",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Boss_BossID",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Department_DepartmentID",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "OfficeAssignment");

            migrationBuilder.DropTable(
                name: "Boss");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_AssignmentID1",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_BossID",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_DepartmentID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentID1",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "BossID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentID",
                table: "Assignments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
