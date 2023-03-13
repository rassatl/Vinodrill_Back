using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinodrill_Back.Migrations.AuthDb
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "t_e_usertoken_uto");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "t_e_user_usr");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "t_e_userrole_url");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "t_e_userlogin_ulg");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "t_e_userclaim_ucl");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "t_e_role_rle");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "t_e_roleclaim_rcl");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "t_e_userrole_url",
                newName: "IX_t_e_userrole_url_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "t_e_userlogin_ulg",
                newName: "IX_t_e_userlogin_ulg_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "t_e_userclaim_ucl",
                newName: "IX_t_e_userclaim_ucl_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "t_e_roleclaim_rcl",
                newName: "IX_t_e_roleclaim_rcl_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_usertoken_uto",
                table: "t_e_usertoken_uto",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_user_usr",
                table: "t_e_user_usr",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_userrole_url",
                table: "t_e_userrole_url",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_userlogin_ulg",
                table: "t_e_userlogin_ulg",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_userclaim_ucl",
                table: "t_e_userclaim_ucl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_role_rle",
                table: "t_e_role_rle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_e_roleclaim_rcl",
                table: "t_e_roleclaim_rcl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_roleclaim_rcl_t_e_role_rle_RoleId",
                table: "t_e_roleclaim_rcl",
                column: "RoleId",
                principalTable: "t_e_role_rle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_userclaim_ucl_t_e_user_usr_UserId",
                table: "t_e_userclaim_ucl",
                column: "UserId",
                principalTable: "t_e_user_usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_userlogin_ulg_t_e_user_usr_UserId",
                table: "t_e_userlogin_ulg",
                column: "UserId",
                principalTable: "t_e_user_usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_userrole_url_t_e_role_rle_RoleId",
                table: "t_e_userrole_url",
                column: "RoleId",
                principalTable: "t_e_role_rle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_userrole_url_t_e_user_usr_UserId",
                table: "t_e_userrole_url",
                column: "UserId",
                principalTable: "t_e_user_usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_e_usertoken_uto_t_e_user_usr_UserId",
                table: "t_e_usertoken_uto",
                column: "UserId",
                principalTable: "t_e_user_usr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_e_roleclaim_rcl_t_e_role_rle_RoleId",
                table: "t_e_roleclaim_rcl");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_userclaim_ucl_t_e_user_usr_UserId",
                table: "t_e_userclaim_ucl");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_userlogin_ulg_t_e_user_usr_UserId",
                table: "t_e_userlogin_ulg");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_userrole_url_t_e_role_rle_RoleId",
                table: "t_e_userrole_url");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_userrole_url_t_e_user_usr_UserId",
                table: "t_e_userrole_url");

            migrationBuilder.DropForeignKey(
                name: "FK_t_e_usertoken_uto_t_e_user_usr_UserId",
                table: "t_e_usertoken_uto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_usertoken_uto",
                table: "t_e_usertoken_uto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_userrole_url",
                table: "t_e_userrole_url");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_userlogin_ulg",
                table: "t_e_userlogin_ulg");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_userclaim_ucl",
                table: "t_e_userclaim_ucl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_user_usr",
                table: "t_e_user_usr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_roleclaim_rcl",
                table: "t_e_roleclaim_rcl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_e_role_rle",
                table: "t_e_role_rle");

            migrationBuilder.RenameTable(
                name: "t_e_usertoken_uto",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "t_e_userrole_url",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "t_e_userlogin_ulg",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "t_e_userclaim_ucl",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "t_e_user_usr",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "t_e_roleclaim_rcl",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "t_e_role_rle",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_userrole_url_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_userlogin_ulg_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_userclaim_ucl_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_t_e_roleclaim_rcl_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
