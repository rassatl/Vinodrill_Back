using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class VinoDrillDBCreationV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_prt_id",
                table: "t_e_activite_act");

            migrationBuilder.AddCheckConstraint(
                name: "ck_eth_nb",
                table: "t_e_etoilehotel_eth",
                sql: "eth_nb between 0 and 5");

            migrationBuilder.AddForeignKey(
                name: "fk_prt_act",
                table: "t_e_activite_act",
                column: "prt_id",
                principalTable: "t_h_societe_sct",
                principalColumn: "prt_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_prt_act",
                table: "t_e_activite_act");

            migrationBuilder.DropCheckConstraint(
                name: "ck_eth_nb",
                table: "t_e_etoilehotel_eth");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_activite_act_t_h_societe_sct_prt_id",
                table: "t_e_activite_act",
                column: "prt_id",
                principalTable: "t_h_societe_sct",
                principalColumn: "prt_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
