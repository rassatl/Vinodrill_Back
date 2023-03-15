using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class AddIdCb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_user_usr_t_e_cb_cb_CbClientNavigationIdCb",
                table: "t_e_user_usr");

            migrationBuilder.DropIndex(
                name: "IX_t_e_user_usr_CbClientNavigationIdCb",
                table: "t_e_user_usr");

            migrationBuilder.DropColumn(
                name: "CbClientNavigationIdCb",
                table: "t_e_user_usr");

            migrationBuilder.AddColumn<int>(
                name: "cb_idcb",
                table: "t_e_user_usr",
                type: "integer",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_user_usr_cb_idcb",
                table: "t_e_user_usr",
                column: "cb_idcb");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_user_usr_t_e_cb_cb_cb_idcb",
                table: "t_e_user_usr",
                column: "cb_idcb",
                principalTable: "t_e_cb_cb",
                principalColumn: "cb_idcb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_user_usr_t_e_cb_cb_cb_idcb",
                table: "t_e_user_usr");

            migrationBuilder.DropIndex(
                name: "IX_t_e_user_usr_cb_idcb",
                table: "t_e_user_usr");

            migrationBuilder.DropColumn(
                name: "cb_idcb",
                table: "t_e_user_usr");

            migrationBuilder.AddColumn<int>(
                name: "CbClientNavigationIdCb",
                table: "t_e_user_usr",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_user_usr_CbClientNavigationIdCb",
                table: "t_e_user_usr",
                column: "CbClientNavigationIdCb");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_user_usr_t_e_cb_cb_CbClientNavigationIdCb",
                table: "t_e_user_usr",
                column: "CbClientNavigationIdCb",
                principalTable: "t_e_cb_cb",
                principalColumn: "cb_idcb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
