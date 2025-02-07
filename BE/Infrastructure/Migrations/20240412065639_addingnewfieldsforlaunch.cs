using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingnewfieldsforlaunch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dg_field_calculations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calc_field1 = table.Column<int>(type: "int", nullable: false),
                    calc_field1_transformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calc_field2 = table.Column<int>(type: "int", nullable: false),
                    mid_operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calc_field2_transformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enable_post_operator = table.Column<bool>(type: "bit", nullable: false),
                    post_operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_operator_val = table.Column<int>(type: "int", nullable: true),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_field_calculations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dg_field_codes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suspect_icd10 = table.Column<int>(type: "int", nullable: false),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    trigger_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trigger_match = table.Column<int>(type: "int", nullable: true),
                    trigger_range_min = table.Column<int>(type: "int", nullable: true),
                    trigger_range_max = table.Column<int>(type: "int", nullable: true),
                    qualifier_value = table.Column<int>(type: "int", nullable: true),
                    text_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_field_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dg_field_cpt_code",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpt_code_id = table.Column<int>(type: "int", nullable: false),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    trigger_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trigger_match = table.Column<int>(type: "int", nullable: true),
                    trigger_range_min = table.Column<int>(type: "int", nullable: true),
                    trigger_range_max = table.Column<int>(type: "int", nullable: true),
                    qualifier_value = table.Column<int>(type: "int", nullable: true),
                    text_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_field_cpt_code", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dg_field_responses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    ideal_choice = table.Column<bool>(type: "bit", nullable: true),
                    response_sort_order = table.Column<int>(type: "int", nullable: false),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_field_responses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dg_fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    field_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    has_response_values = table.Column<bool>(type: "bit", nullable: false),
                    is_required = table.Column<bool>(type: "bit", nullable: false),
                    is_integer_only = table.Column<bool>(type: "bit", nullable: true),
                    integer_validation_min = table.Column<int>(type: "int", nullable: true),
                    integer_validation_max = table.Column<int>(type: "int", nullable: true),
                    lookup_dataset = table.Column<int>(type: "int", nullable: true),
                    lookup_dataset_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datagrid_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    show_in_tabular = table.Column<bool>(type: "bit", nullable: false),
                    tabular_sort_order = table.Column<int>(type: "int", nullable: false),
                    show_in_detail = table.Column<bool>(type: "bit", nullable: false),
                    detail_sort_order = table.Column<int>(type: "int", nullable: false),
                    response_count = table.Column<int>(type: "int", nullable: false),
                    field_tooltip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field_selected_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edited_field_result_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dg_fields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "master_cpt",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    codeset = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    codeset_version = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_sensitive = table.Column<bool>(type: "bit", nullable: false),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master_cpt", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "master_dg_lookup_datasets",
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
                    table.PrimaryKey("PK_master_dg_lookup_datasets", x => x.id);
                });

            //migrationBuilder.CreateTable(
            //    name: "master_Dg_Types",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        code = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        active = table.Column<bool>(type: "bit", nullable: false),
            //        created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        created_by = table.Column<int>(type: "int", nullable: false),
            //        modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        modified_by = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_master_Dg_Types", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "master_icd",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    codeset = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    codeset_version = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active_start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    active_end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_sensitive = table.Column<bool>(type: "bit", nullable: false),
                    categoryCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    isBillable = table.Column<bool>(type: "bit", nullable: false),
                    is_billable = table.Column<bool>(type: "bit", nullable: false),
                    hcc_code = table.Column<int>(type: "int", nullable: true),
                    created_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    modified_datetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master_icd", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DgFieldCodesDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suspect_icd10 = table.Column<int>(type: "int", nullable: false),
                    suspect_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suspect_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    trigger_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trigger_match = table.Column<int>(type: "int", nullable: true),
                    trigger_range_min = table.Column<int>(type: "int", nullable: true),
                    trigger_range_max = table.Column<int>(type: "int", nullable: true),
                    qualifier_value = table.Column<int>(type: "int", nullable: true),
                    text_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datagrid_id = table.Column<int>(type: "int", nullable: true),
                    DgFieldid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgFieldCodesDto", x => x.id);
                    table.ForeignKey(
                        name: "FK_DgFieldCodesDto_dg_fields_DgFieldid",
                        column: x => x.DgFieldid,
                        principalTable: "dg_fields",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DgFieldCPTCodesDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cpt_code_id = table.Column<int>(type: "int", nullable: false),
                    cpt_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpt_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    field_type_id = table.Column<int>(type: "int", nullable: false),
                    trigger_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trigger_match = table.Column<int>(type: "int", nullable: true),
                    trigger_range_min = table.Column<int>(type: "int", nullable: true),
                    trigger_range_max = table.Column<int>(type: "int", nullable: true),
                    qualifier_value = table.Column<int>(type: "int", nullable: true),
                    text_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DgFieldid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgFieldCPTCodesDto", x => x.id);
                    table.ForeignKey(
                        name: "FK_DgFieldCPTCodesDto_dg_fields_DgFieldid",
                        column: x => x.DgFieldid,
                        principalTable: "dg_fields",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DgFieldResponseDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    field_id = table.Column<int>(type: "int", nullable: false),
                    ideal_choice = table.Column<bool>(type: "bit", nullable: true),
                    response_sort_order = table.Column<int>(type: "int", nullable: false),
                    isNotValid = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    DgFieldid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgFieldResponseDto", x => x.id);
                    table.ForeignKey(
                        name: "FK_DgFieldResponseDto_dg_fields_DgFieldid",
                        column: x => x.DgFieldid,
                        principalTable: "dg_fields",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DgFieldCodesDto_DgFieldid",
                table: "DgFieldCodesDto",
                column: "DgFieldid");

            migrationBuilder.CreateIndex(
                name: "IX_DgFieldCPTCodesDto_DgFieldid",
                table: "DgFieldCPTCodesDto",
                column: "DgFieldid");

            migrationBuilder.CreateIndex(
                name: "IX_DgFieldResponseDto_DgFieldid",
                table: "DgFieldResponseDto",
                column: "DgFieldid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dg_field_calculations");

            migrationBuilder.DropTable(
                name: "dg_field_codes");

            migrationBuilder.DropTable(
                name: "dg_field_cpt_code");

            migrationBuilder.DropTable(
                name: "dg_field_responses");

            migrationBuilder.DropTable(
                name: "DgFieldCodesDto");

            migrationBuilder.DropTable(
                name: "DgFieldCPTCodesDto");

            migrationBuilder.DropTable(
                name: "DgFieldResponseDto");

            migrationBuilder.DropTable(
                name: "master_cpt");

            migrationBuilder.DropTable(
                name: "master_dg_lookup_datasets");

            migrationBuilder.DropTable(
                name: "master_Dg_Types");

            migrationBuilder.DropTable(
                name: "master_icd");

            migrationBuilder.DropTable(
                name: "dg_fields");
        }
    }
}
