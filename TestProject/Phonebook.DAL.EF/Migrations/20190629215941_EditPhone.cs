using Microsoft.EntityFrameworkCore.Migrations;

namespace Phonebook.DAL.EF.Migrations
{
    public partial class EditPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phones_people_PersonId",
                table: "phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "phones",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_phones_people_PersonId",
                table: "phones",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_phones_people_PersonId",
                table: "phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "phones",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_phones_people_PersonId",
                table: "phones",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
