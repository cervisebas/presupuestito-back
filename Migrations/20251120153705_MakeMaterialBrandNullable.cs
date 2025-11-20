using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresupuestitoBack.Migrations
{
    /// <inheritdoc />
    public partial class MakeMaterialBrandNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialBrand",
                table: "Materials",
                type: "NVARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaterialBrand",
                table: "Materials",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldNullable: true);
        }
    }
}
