using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.DAL.EF.Migrations
{
    public partial class addPersonStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "people",
                nullable: false,
                defaultValue: true);  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "people",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
