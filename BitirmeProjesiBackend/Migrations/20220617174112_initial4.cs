using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesiBackend.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Point",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Point",
                table: "Users",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
