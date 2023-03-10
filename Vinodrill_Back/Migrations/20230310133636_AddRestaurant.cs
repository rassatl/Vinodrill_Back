using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class AddRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_etoilerestaurant_etr",
                columns: table => new
                {
                    etr_nb = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_etoilerestaurant_etr", x => x.etr_nb);
                });

            migrationBuilder.CreateTable(
                name: "t_e_type_cuisine_tcu",
                columns: table => new
                {
                    tcu_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tcu_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_type_cuisine_tcu", x => x.tcu_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_restaurant_res",
                columns: table => new
                {
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    tcu_id = table.Column<int>(type: "integer", nullable: false),
                    etr_nb = table.Column<int>(type: "integer", nullable: false),
                    res_specialite = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_restaurant_res", x => x.prt_id);
                    table.ForeignKey(
                        name: "fk_etr_res",
                        column: x => x.etr_nb,
                        principalTable: "t_e_etoilerestaurant_etr",
                        principalColumn: "etr_nb");
                    table.ForeignKey(
                        name: "FK_t_e_restaurant_res_t_e_partenaire_prt_prt_id",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tcu_res",
                        column: x => x.tcu_id,
                        principalTable: "t_e_type_cuisine_tcu",
                        principalColumn: "tcu_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_restaurant_res_etr_nb",
                table: "t_e_restaurant_res",
                column: "etr_nb");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_restaurant_res_tcu_id",
                table: "t_e_restaurant_res",
                column: "tcu_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_restaurant_res");

            migrationBuilder.DropTable(
                name: "t_e_etoilerestaurant_etr");

            migrationBuilder.DropTable(
                name: "t_e_type_cuisine_tcu");
        }
    }
}
