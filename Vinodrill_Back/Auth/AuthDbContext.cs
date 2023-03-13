using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Vinodrill_Back.Auth
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>(b =>
            {
                b
                   .HasIndex(e => e.Email)
                   .IsUnique()
                   .HasDatabaseName("uq_clt_email");

                b.ToTable("t_e_user_usr");

                b.Ignore(c => c.PhoneNumberConfirmed);
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("t_e_userclaim_ucl");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("t_e_userlogin_ulg");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("t_e_usertoken_uto");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("t_e_role_rle");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("t_e_roleclaim_rcl");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("t_e_userrole_url");
            });
        }
    }
}