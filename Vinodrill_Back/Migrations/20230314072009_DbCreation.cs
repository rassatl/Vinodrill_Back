using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class DbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_catparticipant_cppt",
                columns: table => new
                {
                    cppt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cppt_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_catparticipant_cppt", x => x.cppt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_cb_cb",
                columns: table => new
                {
                    cb_idcb = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cb_cvc = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cb_code = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cb_anneeexp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cb_moisexp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_cb_cb", x => x.cb_idcb);
                });

            migrationBuilder.CreateTable(
                name: "t_e_destination_dst",
                columns: table => new
                {
                    dst_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dst_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    dst_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_destination", x => x.dst_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_etoilehotel_eth",
                columns: table => new
                {
                    eth_nb = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_etoilehotel_eth", x => x.eth_nb);
                    table.CheckConstraint("ck_eth_nb", "eth_nb between 0 and 5");
                });

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
                name: "t_e_image_img",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    img_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_image_img", x => x.img_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_partenaire_prt",
                columns: table => new
                {
                    prt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prt_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    prt_rue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    prt_cp = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    prt_ville = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    prt_photo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    prt_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    prt_contact = table.Column<string>(type: "char(10)", nullable: false),
                    prt_detailpartenaire = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_partenaire_prt", x => x.prt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_theme_thm",
                columns: table => new
                {
                    thm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    thm_libelle = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    thm_imgthemepage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    thm_contenuthemepage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_theme_thm", x => x.thm_id);
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
                name: "t_e_typeactivite_tac",
                columns: table => new
                {
                    tac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tac_libelletype = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_typeactivite_tac", x => x.tac_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typevisite_tvs",
                columns: table => new
                {
                    tvs_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tvs_libelle = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_typevisite_tvs", x => x.tvs_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_client_clt",
                columns: table => new
                {
                    avi_idavis = table.Column<int>(type: "integer", nullable: true),
                    cb_idcb = table.Column<int>(type: "integer", nullable: true),
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_prenom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    clt_sexe = table.Column<string>(type: "text", nullable: false),
                    clt_motdepasse = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_client_clt", x => x.clt_id);
                    table.ForeignKey(
                        name: "FK_t_e_client_clt_t_e_cb_cb_cb_idcb",
                        column: x => x.cb_idcb,
                        principalTable: "t_e_cb_cb",
                        principalColumn: "cb_idcb");
                });

            migrationBuilder.CreateTable(
                name: "t_h_cave_cav",
                columns: table => new
                {
                    prt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_cave_cav", x => x.prt_id);
                    table.ForeignKey(
                        name: "fk_prt_cav",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id");
                });

            migrationBuilder.CreateTable(
                name: "t_h_hotel_htl",
                columns: table => new
                {
                    ect_nb = table.Column<int>(type: "integer", nullable: false),
                    prt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_hotel_htl", x => x.prt_id);
                    table.ForeignKey(
                        name: "fk_eth_htl",
                        column: x => x.ect_nb,
                        principalTable: "t_e_etoilehotel_eth",
                        principalColumn: "eth_nb");
                    table.ForeignKey(
                        name: "fk_prt_htl",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_sejour_sjr",
                columns: table => new
                {
                    thm_id = table.Column<int>(type: "integer", nullable: false),
                    dst_id = table.Column<int>(type: "integer", nullable: false),
                    sjr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sjr_titre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sjr_photo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sjr_prix = table.Column<decimal>(type: "numeric", nullable: false),
                    sjr_description = table.Column<string>(type: "text", nullable: false),
                    sjr_nbjour = table.Column<int>(type: "integer", nullable: true),
                    sjr_nbnuit = table.Column<int>(type: "integer", nullable: true),
                    sjr_libelletemps = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sjr_notemoyenne = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sejour_sjr", x => x.sjr_id);
                    table.ForeignKey(
                        name: "fk_dst_sjr",
                        column: x => x.dst_id,
                        principalTable: "t_e_destination_dst",
                        principalColumn: "dst_id");
                    table.ForeignKey(
                        name: "fk_thm_sjr",
                        column: x => x.thm_id,
                        principalTable: "t_e_theme_thm",
                        principalColumn: "thm_id");
                });

            migrationBuilder.CreateTable(
                name: "t_h_restaurant_res",
                columns: table => new
                {
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    tcu_id = table.Column<int>(type: "integer", nullable: false),
                    etr_nb = table.Column<int>(type: "integer", nullable: false),
                    res_specialite = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_restaurant_res", x => x.prt_id);
                    table.ForeignKey(
                        name: "fk_etr_res",
                        column: x => x.etr_nb,
                        principalTable: "t_e_etoilerestaurant_etr",
                        principalColumn: "etr_nb");
                    table.ForeignKey(
                        name: "FK_t_h_restaurant_res_t_e_partenaire_prt_prt_id",
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

            migrationBuilder.CreateTable(
                name: "t_h_societe_sct",
                columns: table => new
                {
                    tac_id = table.Column<int>(type: "integer", nullable: false),
                    prt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_societe_sct", x => x.prt_id);
                    table.ForeignKey(
                        name: "fk_prt_sct",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id");
                    table.ForeignKey(
                        name: "fk_tac_sct",
                        column: x => x.tac_id,
                        principalTable: "t_e_typeactivite_tac",
                        principalColumn: "tac_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_adresse_adr",
                columns: table => new
                {
                    adr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_idclient = table.Column<int>(type: "integer", nullable: false),
                    adr_libelle = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    adr_rueadresse = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    adr_ville = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    adr_cp = table.Column<string>(type: "text", nullable: false),
                    adr_pays = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_adresse_adr", x => x.adr_id);
                    table.ForeignKey(
                        name: "fk_clt_adr",
                        column: x => x.clt_idclient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id");
                });

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

            migrationBuilder.CreateTable(
                name: "t_e_paiement_pmt",
                columns: table => new
                {
                    pmt_idpmt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_idclient = table.Column<int>(type: "integer", nullable: false),
                    pmt_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    pmt_preference = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_paiement_pmt", x => x.pmt_idpmt);
                    table.ForeignKey(
                        name: "fk_clt_pmt",
                        column: x => x.clt_idclient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_visite_vst",
                columns: table => new
                {
                    tvs_id = table.Column<int>(type: "integer", nullable: false),
                    cav_id = table.Column<int>(type: "integer", nullable: false),
                    vst_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vst_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    vst_description = table.Column<string>(type: "text", nullable: false),
                    vst_horaire = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_visite_vst", x => x.vst_id);
                    table.ForeignKey(
                        name: "fk_cav_vst",
                        column: x => x.cav_id,
                        principalTable: "t_h_cave_cav",
                        principalColumn: "prt_id");
                    table.ForeignKey(
                        name: "fk_tvs_vst",
                        column: x => x.tvs_id,
                        principalTable: "t_e_typevisite_tvs",
                        principalColumn: "tvs_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_hebergement_hbg",
                columns: table => new
                {
                    hbg_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    hbg_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    hbg_description = table.Column<string>(type: "text", nullable: false),
                    hbg_nbchambre = table.Column<int>(type: "integer", nullable: false),
                    hbg_horaire = table.Column<TimeOnly>(type: "time without time zone", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_hebergement_hbg", x => x.hbg_id);
                    table.ForeignKey(
                        name: "fk_prt_hbg",
                        column: x => x.prt_id,
                        principalTable: "t_h_hotel_htl",
                        principalColumn: "prt_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_avis_avi",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    sjr_id = table.Column<int>(type: "integer", nullable: false),
                    avi_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    avi_note = table.Column<int>(type: "integer", nullable: false),
                    avi_commentaire = table.Column<string>(type: "text", nullable: false),
                    avi_titreavis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    avi_dateavis = table.Column<DateTime>(type: "date", nullable: false),
                    avi_avissignale = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    avi_typesignalement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_avis_avi", x => x.avi_id);
                    table.ForeignKey(
                        name: "fk_clt_avi",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id");
                    table.ForeignKey(
                        name: "fk_sej_avi",
                        column: x => x.clt_id,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_participe_ppt",
                columns: table => new
                {
                    cpt_id = table.Column<int>(type: "integer", nullable: false),
                    sjr_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participe", x => new { x.cpt_id, x.sjr_id });
                    table.ForeignKey(
                        name: "fk_cpt_ppt",
                        column: x => x.cpt_id,
                        principalTable: "t_e_catparticipant_cppt",
                        principalColumn: "cppt_id");
                    table.ForeignKey(
                        name: "fk_sjr_ppt",
                        column: x => x.sjr_id,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_activite_act",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    act_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    act_description = table.Column<string>(type: "text", nullable: false),
                    act_ruerdv = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    act_cprdv = table.Column<string>(type: "char(5)", nullable: false),
                    act_villerdv = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    act_horaire = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_activite_act", x => x.act_id);
                    table.ForeignKey(
                        name: "fk_prt_act",
                        column: x => x.prt_id,
                        principalTable: "t_h_societe_sct",
                        principalColumn: "prt_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_cmd",
                columns: table => new
                {
                    clt_idclient = table.Column<int>(type: "integer", nullable: false),
                    cmd_idpaiement = table.Column<int>(type: "integer", nullable: true),
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_datecommande = table.Column<DateTime>(type: "date", nullable: false),
                    cmd_prixcommande = table.Column<decimal>(type: "numeric", nullable: false),
                    cmd_quantite = table.Column<int>(type: "integer", nullable: false),
                    cmd_message = table.Column<string>(type: "text", nullable: false),
                    cmd_cheminfacture = table.Column<string>(type: "text", nullable: false),
                    cmd_estcheque = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_commande_cmd", x => x.cmd_id);
                    table.CheckConstraint("ck_cmd_prix", "cmd_quantite > 0");
                    table.ForeignKey(
                        name: "fk_clt_cmd",
                        column: x => x.clt_idclient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id");
                    table.ForeignKey(
                        name: "fk_pmt_cmd",
                        column: x => x.cmd_idpaiement,
                        principalTable: "t_e_paiement_pmt",
                        principalColumn: "pmt_idpmt");
                });

            migrationBuilder.CreateTable(
                name: "t_e_etape_etp",
                columns: table => new
                {
                    sjr_id = table.Column<int>(type: "integer", nullable: false),
                    hbg_id = table.Column<int>(type: "integer", nullable: false),
                    etp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etp_titre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    etp_description = table.Column<string>(type: "text", nullable: false),
                    etp_photo = table.Column<string>(type: "text", nullable: false),
                    etp_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    etp_video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_etape_etp", x => x.etp_id);
                    table.ForeignKey(
                        name: "fk_hbg_etp",
                        column: x => x.hbg_id,
                        principalTable: "t_e_hebergement_hbg",
                        principalColumn: "hbg_id");
                    table.ForeignKey(
                        name: "fk_sje_etp",
                        column: x => x.sjr_id,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_reponseavis_rav",
                columns: table => new
                {
                    rav_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rav_idavis = table.Column<int>(type: "integer", nullable: false),
                    rav_commentaire = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reponse_avis", x => new { x.rav_id, x.rav_idavis });
                    table.ForeignKey(
                        name: "fk_avi_rav",
                        column: x => x.rav_idavis,
                        principalTable: "t_e_avis_avi",
                        principalColumn: "avi_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_imageavis_ima",
                columns: table => new
                {
                    avi_id = table.Column<int>(type: "integer", nullable: false),
                    im_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_avis", x => new { x.im_id, x.avi_id });
                    table.ForeignKey(
                        name: "fk_avi_ima",
                        column: x => x.avi_id,
                        principalTable: "t_e_avis_avi",
                        principalColumn: "avi_id");
                    table.ForeignKey(
                        name: "fk_img_ima",
                        column: x => x.im_id,
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_boncommande_bcm",
                columns: table => new
                {
                    bcm_id = table.Column<int>(type: "integer", nullable: false),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    bcm_codeboncommande = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    bcm_datevalidite = table.Column<DateTime>(type: "date", nullable: false),
                    bcm_estvalide = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_boncommande_bcm", x => x.bcm_id);
                    table.ForeignKey(
                        name: "fk_cmd_bcm",
                        column: x => x.bcm_id,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id");
                });

            migrationBuilder.CreateTable(
                name: "t_e_bonreduction_brd",
                columns: table => new
                {
                    brd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    brd_codebonreduction = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    brd_datevalidite = table.Column<DateTime>(type: "date", nullable: false),
                    brd_estvalide = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_bonreduction_brd", x => x.brd_id);
                    table.ForeignKey(
                        name: "fk_cmd_brd",
                        column: x => x.cmd_id,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_reservation_rsv",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    sjr_id = table.Column<int>(type: "integer", nullable: false),
                    rsv_datedebutreservation = table.Column<DateTime>(type: "date", nullable: false),
                    rsv_estcadeau = table.Column<bool>(type: "boolean", nullable: false),
                    rsv_nbenfant = table.Column<int>(type: "integer", nullable: false),
                    rsv_nbadulte = table.Column<int>(type: "integer", nullable: false),
                    rsv_nbchambre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservation", x => new { x.sjr_id, x.cmd_id });
                    table.ForeignKey(
                        name: "fk_cmd_rsv",
                        column: x => x.cmd_id,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id");
                    table.ForeignKey(
                        name: "fk_sjr_rsv",
                        column: x => x.sjr_id,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_effectue_efc",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    etp_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_effectue", x => new { x.act_id, x.etp_id });
                    table.ForeignKey(
                        name: "fk_etp_efc",
                        column: x => x.etp_id,
                        principalTable: "t_e_etape_etp",
                        principalColumn: "etp_id");
                    table.ForeignKey(
                        name: "fk_vst_efc",
                        column: x => x.act_id,
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id");
                });

            migrationBuilder.CreateTable(
                name: "t_j_faitpartiede_fpd",
                columns: table => new
                {
                    vst_id = table.Column<int>(type: "integer", nullable: false),
                    etp_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fait_parti_de", x => new { x.vst_id, x.etp_id });
                    table.ForeignKey(
                        name: "fk_etp_fpd",
                        column: x => x.etp_id,
                        principalTable: "t_e_etape_etp",
                        principalColumn: "etp_id");
                    table.ForeignKey(
                        name: "fk_vst_fpd",
                        column: x => x.vst_id,
                        principalTable: "t_e_visite_vst",
                        principalColumn: "vst_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_prt_id",
                table: "t_e_activite_act",
                column: "prt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_clt_idclient",
                table: "t_e_adresse_adr",
                column: "clt_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avis_avi_clt_id",
                table: "t_e_avis_avi",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avispartenaire_apr_clt_id",
                table: "t_e_avispartenaire_apr",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avispartenaire_apr_par_id",
                table: "t_e_avispartenaire_apr",
                column: "par_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_bonreduction_brd_cmd_id",
                table: "t_e_bonreduction_brd",
                column: "cmd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_cb_idcb",
                table: "t_e_client_clt",
                column: "cb_idcb");

            migrationBuilder.CreateIndex(
                name: "uq_clt_email",
                table: "t_e_client_clt",
                column: "clt_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_clt_idclient",
                table: "t_e_commande_cmd",
                column: "clt_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_cmd_idpaiement",
                table: "t_e_commande_cmd",
                column: "cmd_idpaiement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_etape_etp_hbg_id",
                table: "t_e_etape_etp",
                column: "hbg_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_etape_etp_sjr_id",
                table: "t_e_etape_etp",
                column: "sjr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_hebergement_hbg_prt_id",
                table: "t_e_hebergement_hbg",
                column: "prt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_paiement_pmt_clt_idclient",
                table: "t_e_paiement_pmt",
                column: "clt_idclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponseavis_rav_rav_idavis",
                table: "t_e_reponseavis_rav",
                column: "rav_idavis");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_sejour_sjr_dst_id",
                table: "t_e_sejour_sjr",
                column: "dst_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_sejour_sjr_thm_id",
                table: "t_e_sejour_sjr",
                column: "thm_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_cav_id",
                table: "t_e_visite_vst",
                column: "cav_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_tvs_id",
                table: "t_e_visite_vst",
                column: "tvs_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_hotel_htl_ect_nb",
                table: "t_h_hotel_htl",
                column: "ect_nb");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_restaurant_res_etr_nb",
                table: "t_h_restaurant_res",
                column: "etr_nb");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_restaurant_res_tcu_id",
                table: "t_h_restaurant_res",
                column: "tcu_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_societe_sct_tac_id",
                table: "t_h_societe_sct",
                column: "tac_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_effectue_efc_etp_id",
                table: "t_j_effectue_efc",
                column: "etp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_faitpartiede_fpd_etp_id",
                table: "t_j_faitpartiede_fpd",
                column: "etp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_avi_id",
                table: "t_j_imageavis_ima",
                column: "avi_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_participe_ppt_sjr_id",
                table: "t_j_participe_ppt",
                column: "sjr_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_reservation_rsv_cmd_id",
                table: "t_j_reservation_rsv",
                column: "cmd_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_adresse_adr");

            migrationBuilder.DropTable(
                name: "t_e_avispartenaire_apr");

            migrationBuilder.DropTable(
                name: "t_e_boncommande_bcm");

            migrationBuilder.DropTable(
                name: "t_e_bonreduction_brd");

            migrationBuilder.DropTable(
                name: "t_e_reponseavis_rav");

            migrationBuilder.DropTable(
                name: "t_h_restaurant_res");

            migrationBuilder.DropTable(
                name: "t_j_effectue_efc");

            migrationBuilder.DropTable(
                name: "t_j_faitpartiede_fpd");

            migrationBuilder.DropTable(
                name: "t_j_imageavis_ima");

            migrationBuilder.DropTable(
                name: "t_j_participe_ppt");

            migrationBuilder.DropTable(
                name: "t_j_reservation_rsv");

            migrationBuilder.DropTable(
                name: "t_e_etoilerestaurant_etr");

            migrationBuilder.DropTable(
                name: "t_e_type_cuisine_tcu");

            migrationBuilder.DropTable(
                name: "t_e_activite_act");

            migrationBuilder.DropTable(
                name: "t_e_etape_etp");

            migrationBuilder.DropTable(
                name: "t_e_visite_vst");

            migrationBuilder.DropTable(
                name: "t_e_avis_avi");

            migrationBuilder.DropTable(
                name: "t_e_image_img");

            migrationBuilder.DropTable(
                name: "t_e_catparticipant_cppt");

            migrationBuilder.DropTable(
                name: "t_e_commande_cmd");

            migrationBuilder.DropTable(
                name: "t_h_societe_sct");

            migrationBuilder.DropTable(
                name: "t_e_hebergement_hbg");

            migrationBuilder.DropTable(
                name: "t_h_cave_cav");

            migrationBuilder.DropTable(
                name: "t_e_typevisite_tvs");

            migrationBuilder.DropTable(
                name: "t_e_sejour_sjr");

            migrationBuilder.DropTable(
                name: "t_e_paiement_pmt");

            migrationBuilder.DropTable(
                name: "t_e_typeactivite_tac");

            migrationBuilder.DropTable(
                name: "t_h_hotel_htl");

            migrationBuilder.DropTable(
                name: "t_e_destination_dst");

            migrationBuilder.DropTable(
                name: "t_e_theme_thm");

            migrationBuilder.DropTable(
                name: "t_e_client_clt");

            migrationBuilder.DropTable(
                name: "t_e_etoilehotel_eth");

            migrationBuilder.DropTable(
                name: "t_e_partenaire_prt");

            migrationBuilder.DropTable(
                name: "t_e_cb_cb");
        }
    }
}
