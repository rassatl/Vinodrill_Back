using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class ChangesForNewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clt_idclient",
                table: "t_e_paiement_pmt",
                newName: "usr_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_paiement_pmt_clt_idclient",
                table: "t_e_paiement_pmt",
                newName: "IX_t_e_paiement_pmt_usr_id");

            migrationBuilder.RenameColumn(
                name: "clt_idclient",
                table: "t_e_commande_cmd",
                newName: "usr_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_commande_cmd_clt_idclient",
                table: "t_e_commande_cmd",
                newName: "IX_t_e_commande_cmd_usr_id");

            migrationBuilder.RenameColumn(
                name: "clt_id",
                table: "t_e_avispartenaire_apr",
                newName: "usr_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_avispartenaire_apr_clt_id",
                table: "t_e_avispartenaire_apr",
                newName: "IX_t_e_avispartenaire_apr_usr_id");

            migrationBuilder.RenameColumn(
                name: "clt_id",
                table: "t_e_avis_avi",
                newName: "usr_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_avis_avi_clt_id",
                table: "t_e_avis_avi",
                newName: "IX_t_e_avis_avi_usr_id");

            migrationBuilder.RenameColumn(
                name: "clt_idclient",
                table: "t_e_adresse_adr",
                newName: "usr_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_adresse_adr_clt_idclient",
                table: "t_e_adresse_adr",
                newName: "IX_t_e_adresse_adr_usr_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usr_id",
                table: "t_e_paiement_pmt",
                newName: "clt_idclient");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_paiement_pmt_usr_id",
                table: "t_e_paiement_pmt",
                newName: "IX_t_e_paiement_pmt_clt_idclient");

            migrationBuilder.RenameColumn(
                name: "usr_id",
                table: "t_e_commande_cmd",
                newName: "clt_idclient");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_commande_cmd_usr_id",
                table: "t_e_commande_cmd",
                newName: "IX_t_e_commande_cmd_clt_idclient");

            migrationBuilder.RenameColumn(
                name: "usr_id",
                table: "t_e_avispartenaire_apr",
                newName: "clt_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_avispartenaire_apr_usr_id",
                table: "t_e_avispartenaire_apr",
                newName: "IX_t_e_avispartenaire_apr_clt_id");

            migrationBuilder.RenameColumn(
                name: "usr_id",
                table: "t_e_avis_avi",
                newName: "clt_id");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_avis_avi_usr_id",
                table: "t_e_avis_avi",
                newName: "IX_t_e_avis_avi_clt_id");

            migrationBuilder.RenameColumn(
                name: "usr_id",
                table: "t_e_adresse_adr",
                newName: "clt_idclient");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_adresse_adr_usr_id",
                table: "t_e_adresse_adr",
                newName: "IX_t_e_adresse_adr_clt_idclient");
        }
    }
}
