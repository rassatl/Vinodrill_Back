using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class AddSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usr_sel",
                table: "t_e_user_usr",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usr_sel",
                table: "t_e_user_usr");
        }
    }
}
