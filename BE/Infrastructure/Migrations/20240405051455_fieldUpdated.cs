using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fieldUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dg_core_master_Dg_Types_type",
                table: "dg_core");

            migrationBuilder.DropForeignKey(
                name: "FK_dg_to_core_dg_core_datagrid_id",
                table: "dg_to_core");

            migrationBuilder.DropForeignKey(
                name: "FK_dg_to_core_role_role_id",
                table: "dg_to_core");

            migrationBuilder.DropIndex(
                name: "IX_dg_core_type",
                table: "dg_core");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dg_to_core",
                table: "dg_to_core");

            migrationBuilder.RenameTable(
                name: "dg_to_core",
                newName: "dg_to_roles");

            migrationBuilder.RenameIndex(
                name: "IX_dg_to_core_role_id",
                table: "dg_to_roles",
                newName: "IX_dg_to_roles_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_dg_to_core_datagrid_id",
                table: "dg_to_roles",
                newName: "IX_dg_to_roles_datagrid_id");

            migrationBuilder.AddColumn<string>(
                name: "MasterDgTypes",
                table: "dg_core",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_dg_to_roles",
                table: "dg_to_roles",
                column: "id");

            //migrationBuilder.CreateTable(
            //    name: "master_dg_field_types",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        code = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        has_response_values = table.Column<bool>(type: "bit", nullable: false),
            //        active = table.Column<bool>(type: "bit", nullable: false),
            //        created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        created_by = table.Column<int>(type: "int", nullable: false),
            //        modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        modified_by = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_master_dg_field_types", x => x.id);
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_dg_to_roles_dg_core_datagrid_id",
                table: "dg_to_roles",
                column: "datagrid_id",
                principalTable: "dg_core",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dg_to_roles_role_role_id",
                table: "dg_to_roles",
                column: "role_id",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dg_to_roles_dg_core_datagrid_id",
                table: "dg_to_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_dg_to_roles_role_role_id",
                table: "dg_to_roles");

            migrationBuilder.DropTable(
                name: "master_dg_field_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dg_to_roles",
                table: "dg_to_roles");

            migrationBuilder.DropColumn(
                name: "MasterDgTypes",
                table: "dg_core");

            migrationBuilder.RenameTable(
                name: "dg_to_roles",
                newName: "dg_to_core");

            migrationBuilder.RenameIndex(
                name: "IX_dg_to_roles_role_id",
                table: "dg_to_core",
                newName: "IX_dg_to_core_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_dg_to_roles_datagrid_id",
                table: "dg_to_core",
                newName: "IX_dg_to_core_datagrid_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dg_to_core",
                table: "dg_to_core",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_dg_core_type",
                table: "dg_core",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "FK_dg_core_master_Dg_Types_type",
                table: "dg_core",
                column: "type",
                principalTable: "master_Dg_Types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dg_to_core_dg_core_datagrid_id",
                table: "dg_to_core",
                column: "datagrid_id",
                principalTable: "dg_core",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dg_to_core_role_role_id",
                table: "dg_to_core",
                column: "role_id",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
