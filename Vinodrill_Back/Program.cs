using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vinodrill_Back.Models.Auth;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Stripe;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Auth.OAuth2;

namespace Vinodrill_Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // For stripe
            builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("Stripe"));

            // For Entity Framework
            builder.Services.AddDbContext<VinodrillDBContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("VinoDrillDbContextRemote")));

            // Add http context
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();

            //// For Identity
            //builder.Services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<AuthDbContext>()
            //    .AddDefaultTokenProviders();

            // Adding Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
                    ValidAudience = builder.Configuration["Jwt:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.Client, Policies.UserPolicy());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
            builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
            builder.Services.AddScoped<IDataRepository<Partenaire>,PartenaireManager>();
            builder.Services.AddScoped<IDataRepository<Destination>, DestinationManager>();
            builder.Services.AddScoped<IDataRepository<Restaurant>, RestaurantManager>();
            builder.Services.AddScoped<IHebergementRepository, HebergementManager>();
            builder.Services.AddScoped<IDataRepository<Cave>, CaveManager>();
            builder.Services.AddScoped<IDataRepository<Effectue>, EffectueManager>();
            builder.Services.AddScoped<IBonCommandeRepository, BonCommandeManager>();
            builder.Services.AddScoped<IAvisRepository, AviManager>();
            builder.Services.AddScoped<ISejourRepository, SejourManager>();
            builder.Services.AddScoped<IUserRepository, UserManager>();
            builder.Services.AddScoped<IDataRepository<CatParticipant>, CatparticipantManager>();
            builder.Services.AddScoped<IDataRepository<Theme>, ThemeManager>();
            builder.Services.AddScoped<IDataRepository<Participe>, ParticipeManager>();
            builder.Services.AddScoped<IBonreductionRepository, BonReductionManager>();
            builder.Services.AddScoped<IcommandeRepository, CommandeManager>();
            builder.Services.AddScoped<IDataRepository<Reservation>, ReservationManager>();
            builder.Services.AddScoped<IPaiementRepository, PaiementManager>();
            builder.Services.AddScoped<IDataRepository<User>, UserManager>();
            builder.Services.AddScoped<IBonreductionRepository, BonReductionManager>();
            builder.Services.AddScoped<IDataRepository<ReponseAvis>, ReponseAvisManager>();
            builder.Services.AddScoped<IDataRepository<Societe>, SocieteManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options =>
            {
                options.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials();
            });

            /*app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = "your-client-id",
                ClientSecret = "your-client-secret",
                CallbackPath = new PathString("/signin-google"),
                Scope = new[] { "email", "profile" }
            });*/

            app.UseHttpsRedirection();

            //app.UseSession();

            // Authentication & Authorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}