using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_client_clt_t_e_cb_cb_cb_idcb",
                table: "t_e_client_clt");

            migrationBuilder.RenameColumn(
                name: "cmd_idclient",
                table: "t_e_commande_cmd",
                newName: "clt_idclient");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_commande_cmd_cmd_idclient",
                table: "t_e_commande_cmd",
                newName: "IX_t_e_commande_cmd_clt_idclient");

            migrationBuilder.AlterColumn<decimal>(
                name: "sjr_notemoyenne",
                table: "t_e_sejour_sjr",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "sjr_nbnuit",
                table: "t_e_sejour_sjr",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "sjr_nbjour",
                table: "t_e_sejour_sjr",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "sjr_libelletemps",
                table: "t_e_sejour_sjr",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "etp_video",
                table: "t_e_etape_etp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "etp_url",
                table: "t_e_etape_etp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "dst_description",
                table: "t_e_destination_dst",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "cmd_idpaiement",
                table: "t_e_commande_cmd",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "cmd_estcheque",
                table: "t_e_commande_cmd",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "cb_idcb",
                table: "t_e_client_clt",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "avi_idavis",
                table: "t_e_client_clt",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "avi_typesignalement",
                table: "t_e_avis_avi",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "avi_titreavis",
                table: "t_e_avis_avi",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<bool>(
                name: "avi_avissignale",
                table: "t_e_avis_avi",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "t_e_avispartenaire_apr",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    par_id = table.Column<int>(type: "integer", nullable: false),
                    apr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apr_commentaire = table.Column<string>(type: "text", maxLength: 255, nullable: false),
                    apr_dateavis = table.Column<DateTime>(type: "date", nullable: false),
                    avi_avissignale = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    avi_typesignalement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_avispartenaire_apr", x => x.apr_id);
                    table.ForeignKey(
                        name: "fk_clt_avp",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id");
                    table.ForeignKey(
                        name: "fk_prt_avp",
                        column: x => x.par_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avispartenaire_apr_clt_id",
                table: "t_e_avispartenaire_apr",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avispartenaire_apr_par_id",
                table: "t_e_avispartenaire_apr",
                column: "par_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_client_clt_t_e_cb_cb_cb_idcb",
                table: "t_e_client_clt",
                column: "cb_idcb",
                principalTable: "t_e_cb_cb",
                principalColumn: "cb_idcb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_client_clt_t_e_cb_cb_cb_idcb",
                table: "t_e_client_clt");

            migrationBuilder.DropTable(
                name: "t_e_avispartenaire_apr");

            migrationBuilder.RenameColumn(
                name: "clt_idclient",
                table: "t_e_commande_cmd",
                newName: "cmd_idclient");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_commande_cmd_clt_idclient",
                table: "t_e_commande_cmd",
                newName: "IX_t_e_commande_cmd_cmd_idclient");

            migrationBuilder.AlterColumn<decimal>(
                name: "sjr_notemoyenne",
                table: "t_e_sejour_sjr",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "sjr_nbnuit",
                table: "t_e_sejour_sjr",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "sjr_nbjour",
                table: "t_e_sejour_sjr",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sjr_libelletemps",
                table: "t_e_sejour_sjr",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "etp_video",
                table: "t_e_etape_etp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "etp_url",
                table: "t_e_etape_etp",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "dst_description",
                table: "t_e_destination_dst",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cmd_idpaiement",
                table: "t_e_commande_cmd",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "cmd_estcheque",
                table: "t_e_commande_cmd",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "cb_idcb",
                table: "t_e_client_clt",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "avi_idavis",
                table: "t_e_client_clt",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "avi_typesignalement",
                table: "t_e_avis_avi",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "avi_titreavis",
                table: "t_e_avis_avi",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "avi_avissignale",
                table: "t_e_avis_avi",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_client_clt_t_e_cb_cb_cb_idcb",
                table: "t_e_client_clt",
                column: "cb_idcb",
                principalTable: "t_e_cb_cb",
                principalColumn: "cb_idcb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
