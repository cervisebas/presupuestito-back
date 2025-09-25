using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresupuestitoBack.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePerson_SplitAddress_AddLocalidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "NVARCHAR(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)");

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "People",
                type: "NVARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)");

            migrationBuilder.AlterColumn<string>(
                name: "CUIT",
                table: "People",
                type: "NVARCHAR(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)");

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "People",
                type: "NVARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "People",
                type: "NVARCHAR(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "People",
                type: "NVARCHAR(20)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locality",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "People");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "People");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "People",
                type: "NVARCHAR(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "People",
                type: "NVARCHAR(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CUIT",
                table: "People",
                type: "NVARCHAR(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
