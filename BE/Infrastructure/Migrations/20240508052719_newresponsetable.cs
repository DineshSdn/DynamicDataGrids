using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newresponsetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isNotValid",
                table: "DgFieldResponseDto");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "DgFieldResponseDto",
                newName: "active");

            migrationBuilder.AlterColumn<bool>(
                name: "ideal_choice",
                table: "DgFieldResponseDto",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "DgFieldResponseDto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_datetime",
                table: "DgFieldResponseDto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "modified_by",
                table: "DgFieldResponseDto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_datetime",
                table: "DgFieldResponseDto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "responsetable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    gridid = table.Column<int>(type: "int", nullable: false),
                    questionid = table.Column<int>(type: "int", nullable: false),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsetable", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responsetable");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "DgFieldResponseDto");

            migrationBuilder.DropColumn(
                name: "created_datetime",
                table: "DgFieldResponseDto");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "DgFieldResponseDto");

            migrationBuilder.DropColumn(
                name: "modified_datetime",
                table: "DgFieldResponseDto");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "DgFieldResponseDto",
                newName: "status");

            migrationBuilder.AlterColumn<bool>(
                name: "ideal_choice",
                table: "DgFieldResponseDto",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "isNotValid",
                table: "DgFieldResponseDto",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
