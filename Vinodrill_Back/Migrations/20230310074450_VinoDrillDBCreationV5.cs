using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class VinoDrillDBCreationV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_j_imageavis_ima_t_e_avis_avi_AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropForeignKey(
                name: "FK_t_j_imageavis_ima_t_e_image_img_ImageImageAvisNavigationIdI~",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropIndex(
                name: "IX_t_j_imageavis_ima_AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropIndex(
                name: "IX_t_j_imageavis_ima_ImageImageAvisNavigationIdImage",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropColumn(
                name: "AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropColumn(
                name: "ImageImageAvisNavigationIdImage",
                table: "t_j_imageavis_ima");

            migrationBuilder.AlterColumn<int>(
                name: "avi_id",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "im_id",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_avi_id",
                table: "t_j_imageavis_ima",
                column: "avi_id");

            migrationBuilder.AddForeignKey(
                name: "fk_avi_ima",
                table: "t_j_imageavis_ima",
                column: "avi_id",
                principalTable: "t_e_avis_avi",
                principalColumn: "avi_id");

            migrationBuilder.AddForeignKey(
                name: "fk_img_ima",
                table: "t_j_imageavis_ima",
                column: "im_id",
                principalTable: "t_e_image_img",
                principalColumn: "img_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_avi_ima",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropForeignKey(
                name: "fk_img_ima",
                table: "t_j_imageavis_ima");

            migrationBuilder.DropIndex(
                name: "IX_t_j_imageavis_ima_avi_id",
                table: "t_j_imageavis_ima");

            migrationBuilder.AlterColumn<int>(
                name: "avi_id",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "im_id",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageImageAvisNavigationIdImage",
                table: "t_j_imageavis_ima",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima",
                column: "AvisImageAvisNavigationIdAvis");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_ImageImageAvisNavigationIdImage",
                table: "t_j_imageavis_ima",
                column: "ImageImageAvisNavigationIdImage");

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_imageavis_ima_t_e_avis_avi_AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima",
                column: "AvisImageAvisNavigationIdAvis",
                principalTable: "t_e_avis_avi",
                principalColumn: "avi_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_j_imageavis_ima_t_e_image_img_ImageImageAvisNavigationIdI~",
                table: "t_j_imageavis_ima",
                column: "ImageImageAvisNavigationIdImage",
                principalTable: "t_e_image_img",
                principalColumn: "img_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
