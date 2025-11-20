using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresupuestitoBack.Migrations
{
    /// <inheritdoc />
    public partial class MakeMaterialFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialUnitMeasure",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialMeasure",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialDescription",
                table: "Materials",
                type: "NVARCHAR(400)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(400)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialColor",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialUnitMeasure",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialMeasure",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialDescription",
                table: "Materials",
                type: "NVARCHAR(400)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(400)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialColor",
                table: "Materials",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)",
                oldNullable: true);
        }
    }
}
