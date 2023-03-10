using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class VinoDrillDBCreationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_SocieteActiviteNavigationI~",
                table: "t_e_activite_act");

            migrationBuilder.DropIndex(
                name: "IX_t_e_activite_act_SocieteActiviteNavigationIdPartenaire",
                table: "t_e_activite_act");

            migrationBuilder.DropColumn(
                name: "SocieteActiviteNavigationIdPartenaire",
                table: "t_e_activite_act");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_prt_id",
                table: "t_e_activite_act",
                column: "prt_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_prt_id",
                table: "t_e_activite_act",
                column: "prt_id",
                principalTable: "t_h_societe_sct",
                principalColumn: "prt_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_prt_id",
                table: "t_e_activite_act");

            migrationBuilder.DropIndex(
                name: "IX_t_e_activite_act_prt_id",
                table: "t_e_activite_act");

            migrationBuilder.AddColumn<int>(
                name: "SocieteActiviteNavigationIdPartenaire",
                table: "t_e_activite_act",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_SocieteActiviteNavigationIdPartenaire",
                table: "t_e_activite_act",
                column: "SocieteActiviteNavigationIdPartenaire");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_SocieteActiviteNavigationI~",
                table: "t_e_activite_act",
                column: "SocieteActiviteNavigationIdPartenaire",
                principalTable: "t_h_societe_sct",
                principalColumn: "prt_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
