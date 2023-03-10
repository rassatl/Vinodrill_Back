using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class VinoDrillDBCreationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_visite_vst_t_h_cave_cav_CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst");

            migrationBuilder.DropForeignKey(
                name: "FK_t_h_cave_cav_t_e_partenaire_prt_PartenaireCaveNavigationIdP~",
                table: "t_h_cave_cav");

            migrationBuilder.DropForeignKey(
                name: "FK_t_j_faitpartiede_fpd_t_e_etape_etp_EtapeFaitPartieDeNavigat~",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropForeignKey(
                name: "FK_t_j_faitpartiede_fpd_t_e_visite_vst_VisiteFaitPartieDeNavig~",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropIndex(
                name: "IX_t_j_faitpartiede_fpd_EtapeFaitPartieDeNavigationIdEtape",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropIndex(
                name: "IX_t_j_faitpartiede_fpd_VisiteFaitPartieDeNavigationIdVisite",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropIndex(
                name: "IX_t_h_cave_cav_PartenaireCaveNavigationIdPartenaire",
                table: "t_h_cave_cav");

            migrationBuilder.DropIndex(
                name: "IX_t_e_visite_vst_CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst");

            migrationBuilder.DropColumn(
                name: "EtapeFaitPartieDeNavigationIdEtape",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropColumn(
                name: "VisiteFaitPartieDeNavigationIdVisite",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropColumn(
                name: "PartenaireCaveNavigationIdPartenaire",
                table: "t_h_cave_cav");

            migrationBuilder.DropColumn(
                name: "CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst");

            migrationBuilder.AlterColumn<int>(
                name: "etp_id",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vst_id",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_faitpartiede_fpd_etp_id",
                table: "t_j_faitpartiede_fpd",
                column: "etp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_cave_cav_prt_id",
                table: "t_h_cave_cav",
                column: "prt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_cav_id",
                table: "t_e_visite_vst",
                column: "cav_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cav_vst",
                table: "t_e_visite_vst",
                column: "cav_id",
                principalTable: "t_h_cave_cav",
                principalColumn: "prt_id");

            migrationBuilder.AddForeignKey(
                name: "fk_prt_cav",
                table: "t_h_cave_cav",
                column: "prt_id",
                principalTable: "t_e_partenaire_prt",
                principalColumn: "prt_id");

            migrationBuilder.AddForeignKey(
                name: "fk_etp_fpd",
                table: "t_j_faitpartiede_fpd",
                column: "etp_id",
                principalTable: "t_e_etape_etp",
                principalColumn: "etp_id");

            migrationBuilder.AddForeignKey(
                name: "fk_vst_fpd",
                table: "t_j_faitpartiede_fpd",
                column: "vst_id",
                principalTable: "t_e_visite_vst",
                principalColumn: "vst_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cav_vst",
                table: "t_e_visite_vst");

            migrationBuilder.DropForeignKey(
                name: "fk_prt_cav",
                table: "t_h_cave_cav");

            migrationBuilder.DropForeignKey(
                name: "fk_etp_fpd",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropForeignKey(
                name: "fk_vst_fpd",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropIndex(
                name: "IX_t_j_faitpartiede_fpd_etp_id",
                table: "t_j_faitpartiede_fpd");

            migrationBuilder.DropIndex(
                name: "IX_t_h_cave_cav_prt_id",
                table: "t_h_cave_cav");

            migrationBuilder.DropIndex(
                name: "IX_t_e_visite_vst_cav_id",
                table: "t_e_visite_vst");

            migrationBuilder.AlterColumn<int>(
                name: "etp_id",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "vst_id",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "EtapeFaitPartieDeNavigationIdEtape",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisiteFaitPartieDeNavigationIdVisite",
                table: "t_j_faitpartiede_fpd",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartenaireCaveNavigationIdPartenaire",
                table: "t_h_cave_cav",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_faitpartiede_fpd_EtapeFaitPartieDeNavigationIdEtape",
                table: "t_j_faitpartiede_fpd",
                column: "EtapeFaitPartieDeNavigationIdEtape");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_faitpartiede_fpd_VisiteFaitPartieDeNavigationIdVisite",
                table: "t_j_faitpartiede_fpd",
                column: "VisiteFaitPartieDeNavigationIdVisite");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_cave_cav_PartenaireCaveNavigationIdPartenaire",
                table: "t_h_cave_cav",
                column: "PartenaireCaveNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst",
                column: "CaveVisiteNavigationIdPartenaire");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_visite_vst_t_h_cave_cav_CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst",
                column: "CaveVisiteNavigationIdPartenaire",
                principalTable: "t_h_cave_cav",
                principalColumn: "prt_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_h_cave_cav_t_e_partenaire_prt_PartenaireCaveNavigationIdP~",
                table: "t_h_cave_cav",
                column: "PartenaireCaveNavigationIdPartenaire",
                principalTable: "t_e_partenaire_prt",
                principalColumn: "prt_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_faitpartiede_fpd_t_e_etape_etp_EtapeFaitPartieDeNavigat~",
                table: "t_j_faitpartiede_fpd",
                column: "EtapeFaitPartieDeNavigationIdEtape",
                principalTable: "t_e_etape_etp",
                principalColumn: "etp_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_faitpartiede_fpd_t_e_visite_vst_VisiteFaitPartieDeNavig~",
                table: "t_j_faitpartiede_fpd",
                column: "VisiteFaitPartieDeNavigationIdVisite",
                principalTable: "t_e_visite_vst",
                principalColumn: "vst_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
