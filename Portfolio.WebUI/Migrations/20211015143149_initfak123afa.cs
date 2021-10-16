using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.WebUI.Migrations
{
    public partial class initfak123afa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contactss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contactss",
                table: "Contactss",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contactss",
                table: "Contactss");

            migrationBuilder.RenameTable(
                name: "Contactss",
                newName: "Contacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }
    }
}
