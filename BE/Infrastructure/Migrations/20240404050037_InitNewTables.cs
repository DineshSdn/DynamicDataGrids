using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "master_Dg_Types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master_Dg_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_nmae = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dg_core",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    show_health_profile = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    code_key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_core", x => x.id);
                    table.ForeignKey(
                        name: "FK_dg_core_master_Dg_Types_type",
                        column: x => x.type,
                        principalTable: "master_Dg_Types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dg_to_core",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datagrid_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_to_core", x => x.id);
                    table.ForeignKey(
                        name: "FK_dg_to_core_dg_core_datagrid_id",
                        column: x => x.datagrid_id,
                        principalTable: "dg_core",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dg_to_core_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dg_core_type",
                table: "dg_core",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_dg_to_core_datagrid_id",
                table: "dg_to_core",
                column: "datagrid_id");

            migrationBuilder.CreateIndex(
                name: "IX_dg_to_core_role_id",
                table: "dg_to_core",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dg_to_core");

            migrationBuilder.DropTable(
                name: "dg_core");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "master_Dg_Types");
        }
    }
}
