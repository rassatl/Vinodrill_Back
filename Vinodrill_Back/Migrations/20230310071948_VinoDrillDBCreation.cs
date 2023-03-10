using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Vinodrill_Back.Migrations
{
    public partial class VinoDrillDBCreation : Migration
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
                    dst_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_destination_dst", x => x.dst_id);
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
                    prt_contact = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
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
                    thm_imgthemepage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    thm_contenuthemepage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_theme_thm", x => x.thm_id);
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
                    avi_idavis = table.Column<int>(type: "integer", nullable: false),
                    cb_idcb = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_prenom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    clt_sexe = table.Column<string>(type: "text", nullable: false),
                    clt_motdepasse = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clt_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CbClientNavigationIdCb = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_client_clt", x => x.clt_id);
                    table.ForeignKey(
                        name: "FK_t_e_client_clt_t_e_cb_cb_CbClientNavigationIdCb",
                        column: x => x.CbClientNavigationIdCb,
                        principalTable: "t_e_cb_cb",
                        principalColumn: "cb_idcb",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_h_cave_cav",
                columns: table => new
                {
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    PartenaireCaveNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_cave_cav", x => x.prt_id);
                    table.ForeignKey(
                        name: "FK_t_h_cave_cav_t_e_partenaire_prt_PartenaireCaveNavigationIdP~",
                        column: x => x.PartenaireCaveNavigationIdPartenaire,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_h_cave_cav_t_e_partenaire_prt_prt_id",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_h_hotel_htl",
                columns: table => new
                {
                    ect_nb = table.Column<int>(type: "integer", nullable: false),
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    PartenaireHotelNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false),
                    EtoileHotelHotelNavigationNbEtoileHotel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_hotel_htl", x => x.prt_id);
                    table.ForeignKey(
                        name: "FK_t_h_hotel_htl_t_e_etoilehotel_eth_EtoileHotelHotelNavigatio~",
                        column: x => x.EtoileHotelHotelNavigationNbEtoileHotel,
                        principalTable: "t_e_etoilehotel_eth",
                        principalColumn: "eth_nb",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_h_hotel_htl_t_e_partenaire_prt_PartenaireHotelNavigationI~",
                        column: x => x.PartenaireHotelNavigationIdPartenaire,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_h_hotel_htl_t_e_partenaire_prt_prt_id",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
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
                    sjr_nbjour = table.Column<int>(type: "integer", nullable: false),
                    sjr_nbnuit = table.Column<int>(type: "integer", nullable: false),
                    sjr_libelletemps = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sjr_notemoyenne = table.Column<decimal>(type: "numeric", nullable: false),
                    DestinationSejourNavigationIdDestination = table.Column<int>(type: "integer", nullable: false),
                    ThemeSejourNavigationIdTheme = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_sejour_sjr", x => x.sjr_id);
                    table.ForeignKey(
                        name: "FK_t_e_sejour_sjr_t_e_destination_dst_DestinationSejourNavigat~",
                        column: x => x.DestinationSejourNavigationIdDestination,
                        principalTable: "t_e_destination_dst",
                        principalColumn: "dst_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_sejour_sjr_t_e_theme_thm_ThemeSejourNavigationIdTheme",
                        column: x => x.ThemeSejourNavigationIdTheme,
                        principalTable: "t_e_theme_thm",
                        principalColumn: "thm_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_h_societe_sct",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    prt_id = table.Column<int>(type: "integer", nullable: false),
                    TypeActiviteSocieteNavigationIdTypeActivite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_h_societe_sct", x => x.prt_id);
                    table.ForeignKey(
                        name: "FK_t_h_societe_sct_t_e_partenaire_prt_prt_id",
                        column: x => x.prt_id,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_h_societe_sct_t_e_typeactivite_tac_TypeActiviteSocieteNav~",
                        column: x => x.TypeActiviteSocieteNavigationIdTypeActivite,
                        principalTable: "t_e_typeactivite_tac",
                        principalColumn: "tac_id",
                        onDelete: ReferentialAction.Cascade);
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
                    adr_pays = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientAdresseNavigationIdClient = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_adresse_adr", x => x.adr_id);
                    table.ForeignKey(
                        name: "FK_t_e_adresse_adr_t_e_client_clt_ClientAdresseNavigationIdCli~",
                        column: x => x.ClientAdresseNavigationIdClient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_paiement_pmt",
                columns: table => new
                {
                    pmt_idpmt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_idclient = table.Column<int>(type: "integer", nullable: false),
                    pmt_libelle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    pmt_preference = table.Column<bool>(type: "boolean", nullable: false),
                    ClientPaiementNavigationIdClient = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_paiement_pmt", x => x.pmt_idpmt);
                    table.ForeignKey(
                        name: "FK_t_e_paiement_pmt_t_e_client_clt_ClientPaiementNavigationIdC~",
                        column: x => x.ClientPaiementNavigationIdClient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
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
                    vst_horaire = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TypeVisiteVisiteNavigationIdTypeVisite = table.Column<int>(type: "integer", nullable: false),
                    CaveVisiteNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_visite_vst", x => x.vst_id);
                    table.ForeignKey(
                        name: "FK_t_e_visite_vst_t_e_typevisite_tvs_TypeVisiteVisiteNavigatio~",
                        column: x => x.TypeVisiteVisiteNavigationIdTypeVisite,
                        principalTable: "t_e_typevisite_tvs",
                        principalColumn: "tvs_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_visite_vst_t_h_cave_cav_CaveVisiteNavigationIdPartenaire",
                        column: x => x.CaveVisiteNavigationIdPartenaire,
                        principalTable: "t_h_cave_cav",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
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
                    hbg_horaire = table.Column<TimeOnly>(type: "time without time zone", maxLength: 255, nullable: false),
                    HotelHebergementNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_hebergement_hbg", x => x.hbg_id);
                    table.ForeignKey(
                        name: "FK_t_e_hebergement_hbg_t_h_hotel_htl_HotelHebergementNavigatio~",
                        column: x => x.HotelHebergementNavigationIdPartenaire,
                        principalTable: "t_h_hotel_htl",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
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
                    avi_titreavis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    avi_dateavis = table.Column<DateTime>(type: "date", nullable: false),
                    avi_avissignale = table.Column<bool>(type: "boolean", nullable: false),
                    avi_typesignalement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClientAvisNavigationIdClient = table.Column<int>(type: "integer", nullable: false),
                    SejourAvisNavigationIdSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_avis_avi", x => x.avi_id);
                    table.ForeignKey(
                        name: "FK_t_e_avis_avi_t_e_client_clt_ClientAvisNavigationIdClient",
                        column: x => x.ClientAvisNavigationIdClient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_avis_avi_t_e_sejour_sjr_SejourAvisNavigationIdSejour",
                        column: x => x.SejourAvisNavigationIdSejour,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_participe_ppt",
                columns: table => new
                {
                    cpt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sjr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CatParticipantParticipeNavigationIdCategorieParticipant = table.Column<int>(type: "integer", nullable: false),
                    SejourParticipeNavigationIdSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participe", x => new { x.cpt_id, x.sjr_id });
                    table.ForeignKey(
                        name: "FK_t_j_participe_ppt_t_e_catparticipant_cppt_CatParticipantPar~",
                        column: x => x.CatParticipantParticipeNavigationIdCategorieParticipant,
                        principalTable: "t_e_catparticipant_cppt",
                        principalColumn: "cppt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_participe_ppt_t_e_sejour_sjr_SejourParticipeNavigationI~",
                        column: x => x.SejourParticipeNavigationIdSejour,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartenaireSociete",
                columns: table => new
                {
                    PartenaireSocieteNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false),
                    SocietePartenaireNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartenaireSociete", x => new { x.PartenaireSocieteNavigationIdPartenaire, x.SocietePartenaireNavigationIdPartenaire });
                    table.ForeignKey(
                        name: "FK_PartenaireSociete_t_e_partenaire_prt_PartenaireSocieteNavig~",
                        column: x => x.PartenaireSocieteNavigationIdPartenaire,
                        principalTable: "t_e_partenaire_prt",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartenaireSociete_t_h_societe_sct_SocietePartenaireNavigati~",
                        column: x => x.SocietePartenaireNavigationIdPartenaire,
                        principalTable: "t_h_societe_sct",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
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
                    act_horaire = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    SocieteActiviteNavigationIdPartenaire = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_activite_act", x => x.act_id);
                    table.ForeignKey(
                        name: "FK_t_e_activite_act_t_h_societe_sct_SocieteActiviteNavigationI~",
                        column: x => x.SocieteActiviteNavigationIdPartenaire,
                        principalTable: "t_h_societe_sct",
                        principalColumn: "prt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commande_cmd",
                columns: table => new
                {
                    cmd_idclient = table.Column<int>(type: "integer", nullable: false),
                    cmd_idpaiement = table.Column<int>(type: "integer", nullable: false),
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_datecommande = table.Column<DateTime>(type: "date", nullable: false),
                    cmd_prixcommande = table.Column<decimal>(type: "numeric", nullable: false),
                    cmd_quantite = table.Column<int>(type: "integer", nullable: false),
                    cmd_message = table.Column<string>(type: "text", nullable: false),
                    cmd_cheminfacture = table.Column<string>(type: "text", nullable: false),
                    cmd_estcheque = table.Column<bool>(type: "boolean", nullable: false),
                    ClientCommandeNavigationIdClient = table.Column<int>(type: "integer", nullable: false),
                    PaiementCommandeNavigationIdPaiement = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_commande_cmd", x => x.cmd_id);
                    table.CheckConstraint("ck_cmd_prix", "cmd_quantite > 0");
                    table.ForeignKey(
                        name: "FK_t_e_commande_cmd_t_e_client_clt_ClientCommandeNavigationIdC~",
                        column: x => x.ClientCommandeNavigationIdClient,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_commande_cmd_t_e_paiement_pmt_PaiementCommandeNavigatio~",
                        column: x => x.PaiementCommandeNavigationIdPaiement,
                        principalTable: "t_e_paiement_pmt",
                        principalColumn: "pmt_idpmt",
                        onDelete: ReferentialAction.Cascade);
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
                    etp_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    etp_video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    HebergementEtapeNavigationIdHebergement = table.Column<int>(type: "integer", nullable: false),
                    SejourEtapeNavigationIdSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_etape_etp", x => x.etp_id);
                    table.ForeignKey(
                        name: "FK_t_e_etape_etp_t_e_hebergement_hbg_HebergementEtapeNavigatio~",
                        column: x => x.HebergementEtapeNavigationIdHebergement,
                        principalTable: "t_e_hebergement_hbg",
                        principalColumn: "hbg_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_e_etape_etp_t_e_sejour_sjr_SejourEtapeNavigationIdSejour",
                        column: x => x.SejourEtapeNavigationIdSejour,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_t_e_reponseavis_rav_t_e_avis_avi_rav_idavis",
                        column: x => x.rav_idavis,
                        principalTable: "t_e_avis_avi",
                        principalColumn: "avi_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_imageavis_ima",
                columns: table => new
                {
                    avi_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    im_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AvisImageAvisNavigationIdAvis = table.Column<int>(type: "integer", nullable: false),
                    ImageImageAvisNavigationIdImage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_image_avis", x => new { x.im_id, x.avi_id });
                    table.ForeignKey(
                        name: "FK_t_j_imageavis_ima_t_e_avis_avi_AvisImageAvisNavigationIdAvis",
                        column: x => x.AvisImageAvisNavigationIdAvis,
                        principalTable: "t_e_avis_avi",
                        principalColumn: "avi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_imageavis_ima_t_e_image_img_ImageImageAvisNavigationIdI~",
                        column: x => x.ImageImageAvisNavigationIdImage,
                        principalTable: "t_e_image_img",
                        principalColumn: "img_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_boncommande_bcm",
                columns: table => new
                {
                    bcm_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    bcm_codeboncommande = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    bcm_datevalidite = table.Column<DateTime>(type: "date", nullable: false),
                    bcm_estvalide = table.Column<bool>(type: "boolean", nullable: false),
                    CommandeBonCommandeNavigationRefCommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_boncommande_bcm", x => x.bcm_id);
                    table.ForeignKey(
                        name: "FK_t_e_boncommande_bcm_t_e_commande_cmd_CommandeBonCommandeNav~",
                        column: x => x.CommandeBonCommandeNavigationRefCommande,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Cascade);
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
                    brd_estvalide = table.Column<bool>(type: "boolean", nullable: false),
                    CommandeBonReductionNavigationRefCommande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_e_bonreduction_brd", x => x.brd_id);
                    table.ForeignKey(
                        name: "FK_t_e_bonreduction_brd_t_e_commande_cmd_CommandeBonReductionN~",
                        column: x => x.CommandeBonReductionNavigationRefCommande,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_reservation_rsv",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sjr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rsv_datedebutreservation = table.Column<DateTime>(type: "date", nullable: false),
                    rsv_estcadeau = table.Column<bool>(type: "boolean", nullable: false),
                    rsv_nbenfant = table.Column<int>(type: "integer", nullable: false),
                    rsv_nbadulte = table.Column<int>(type: "integer", nullable: false),
                    rsv_nbchambre = table.Column<int>(type: "integer", nullable: false),
                    CommandeReservationNavigationRefCommande = table.Column<int>(type: "integer", nullable: false),
                    SejourReservationNavigationIdSejour = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservation", x => new { x.sjr_id, x.cmd_id });
                    table.ForeignKey(
                        name: "FK_t_j_reservation_rsv_t_e_commande_cmd_CommandeReservationNav~",
                        column: x => x.CommandeReservationNavigationRefCommande,
                        principalTable: "t_e_commande_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_reservation_rsv_t_e_sejour_sjr_SejourReservationNavigat~",
                        column: x => x.SejourReservationNavigationIdSejour,
                        principalTable: "t_e_sejour_sjr",
                        principalColumn: "sjr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_effectue_efc",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiviteEffectueNavigationIdActivite = table.Column<int>(type: "integer", nullable: false),
                    EtapeEffectueNavigationIdEtape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_effectue", x => new { x.act_id, x.etp_id });
                    table.ForeignKey(
                        name: "FK_t_j_effectue_efc_t_e_activite_act_ActiviteEffectueNavigatio~",
                        column: x => x.ActiviteEffectueNavigationIdActivite,
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_effectue_efc_t_e_etape_etp_EtapeEffectueNavigationIdEta~",
                        column: x => x.EtapeEffectueNavigationIdEtape,
                        principalTable: "t_e_etape_etp",
                        principalColumn: "etp_id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_t_j_faitpartiede_fpd_t_e_etape_etp_etp_id",
                        column: x => x.etp_id,
                        principalTable: "t_e_etape_etp",
                        principalColumn: "etp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_j_faitpartiede_fpd_t_e_visite_vst_vst_id",
                        column: x => x.vst_id,
                        principalTable: "t_e_visite_vst",
                        principalColumn: "vst_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartenaireSociete_SocietePartenaireNavigationIdPartenaire",
                table: "PartenaireSociete",
                column: "SocietePartenaireNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_SocieteActiviteNavigationIdPartenaire",
                table: "t_e_activite_act",
                column: "SocieteActiviteNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_adresse_adr_ClientAdresseNavigationIdClient",
                table: "t_e_adresse_adr",
                column: "ClientAdresseNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avis_avi_ClientAvisNavigationIdClient",
                table: "t_e_avis_avi",
                column: "ClientAvisNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avis_avi_SejourAvisNavigationIdSejour",
                table: "t_e_avis_avi",
                column: "SejourAvisNavigationIdSejour");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_boncommande_bcm_CommandeBonCommandeNavigationRefCommande",
                table: "t_e_boncommande_bcm",
                column: "CommandeBonCommandeNavigationRefCommande");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_bonreduction_brd_CommandeBonReductionNavigationRefComma~",
                table: "t_e_bonreduction_brd",
                column: "CommandeBonReductionNavigationRefCommande");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_CbClientNavigationIdCb",
                table: "t_e_client_clt",
                column: "CbClientNavigationIdCb");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_ClientCommandeNavigationIdClient",
                table: "t_e_commande_cmd",
                column: "ClientCommandeNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commande_cmd_PaiementCommandeNavigationIdPaiement",
                table: "t_e_commande_cmd",
                column: "PaiementCommandeNavigationIdPaiement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_etape_etp_HebergementEtapeNavigationIdHebergement",
                table: "t_e_etape_etp",
                column: "HebergementEtapeNavigationIdHebergement");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_etape_etp_SejourEtapeNavigationIdSejour",
                table: "t_e_etape_etp",
                column: "SejourEtapeNavigationIdSejour");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_hebergement_hbg_HotelHebergementNavigationIdPartenaire",
                table: "t_e_hebergement_hbg",
                column: "HotelHebergementNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_paiement_pmt_ClientPaiementNavigationIdClient",
                table: "t_e_paiement_pmt",
                column: "ClientPaiementNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponseavis_rav_rav_idavis",
                table: "t_e_reponseavis_rav",
                column: "rav_idavis");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_sejour_sjr_DestinationSejourNavigationIdDestination",
                table: "t_e_sejour_sjr",
                column: "DestinationSejourNavigationIdDestination");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_sejour_sjr_ThemeSejourNavigationIdTheme",
                table: "t_e_sejour_sjr",
                column: "ThemeSejourNavigationIdTheme");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_CaveVisiteNavigationIdPartenaire",
                table: "t_e_visite_vst",
                column: "CaveVisiteNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_visite_vst_TypeVisiteVisiteNavigationIdTypeVisite",
                table: "t_e_visite_vst",
                column: "TypeVisiteVisiteNavigationIdTypeVisite");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_cave_cav_PartenaireCaveNavigationIdPartenaire",
                table: "t_h_cave_cav",
                column: "PartenaireCaveNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_hotel_htl_EtoileHotelHotelNavigationNbEtoileHotel",
                table: "t_h_hotel_htl",
                column: "EtoileHotelHotelNavigationNbEtoileHotel");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_hotel_htl_PartenaireHotelNavigationIdPartenaire",
                table: "t_h_hotel_htl",
                column: "PartenaireHotelNavigationIdPartenaire");

            migrationBuilder.CreateIndex(
                name: "IX_t_h_societe_sct_TypeActiviteSocieteNavigationIdTypeActivite",
                table: "t_h_societe_sct",
                column: "TypeActiviteSocieteNavigationIdTypeActivite");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_effectue_efc_ActiviteEffectueNavigationIdActivite",
                table: "t_j_effectue_efc",
                column: "ActiviteEffectueNavigationIdActivite");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_effectue_efc_EtapeEffectueNavigationIdEtape",
                table: "t_j_effectue_efc",
                column: "EtapeEffectueNavigationIdEtape");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_faitpartiede_fpd_etp_id",
                table: "t_j_faitpartiede_fpd",
                column: "etp_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_AvisImageAvisNavigationIdAvis",
                table: "t_j_imageavis_ima",
                column: "AvisImageAvisNavigationIdAvis");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_imageavis_ima_ImageImageAvisNavigationIdImage",
                table: "t_j_imageavis_ima",
                column: "ImageImageAvisNavigationIdImage");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_participe_ppt_CatParticipantParticipeNavigationIdCatego~",
                table: "t_j_participe_ppt",
                column: "CatParticipantParticipeNavigationIdCategorieParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_participe_ppt_SejourParticipeNavigationIdSejour",
                table: "t_j_participe_ppt",
                column: "SejourParticipeNavigationIdSejour");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_reservation_rsv_CommandeReservationNavigationRefCommande",
                table: "t_j_reservation_rsv",
                column: "CommandeReservationNavigationRefCommande");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_reservation_rsv_SejourReservationNavigationIdSejour",
                table: "t_j_reservation_rsv",
                column: "SejourReservationNavigationIdSejour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartenaireSociete");

            migrationBuilder.DropTable(
                name: "t_e_adresse_adr");

            migrationBuilder.DropTable(
                name: "t_e_boncommande_bcm");

            migrationBuilder.DropTable(
                name: "t_e_bonreduction_brd");

            migrationBuilder.DropTable(
                name: "t_e_reponseavis_rav");

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
                name: "t_e_typevisite_tvs");

            migrationBuilder.DropTable(
                name: "t_h_cave_cav");

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
