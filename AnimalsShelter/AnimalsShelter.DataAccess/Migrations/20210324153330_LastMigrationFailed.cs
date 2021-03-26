using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalsShelter.DataAccess.Migrations
{
    public partial class LastMigrationFailed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "SpiecieId",
                table: "Breeds");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieId",
                table: "Breeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SpiecieId",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Species_SpecieId",
                table: "Breeds",
                column: "SpecieId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
