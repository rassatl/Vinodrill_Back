using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class DBcreatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "uq_prt_email",
                table: "t_e_partenaire_prt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "uq_prt_email",
                table: "t_e_partenaire_prt",
                column: "prt_email",
                unique: true);
        }
    }
}
