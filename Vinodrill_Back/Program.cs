using Microsoft.EntityFrameworkCore;
using Vinodrill_Back.Models.DataManager;
using Vinodrill_Back.Models.EntityFramework;
using Vinodrill_Back.Models.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vinodrill_Back.Auth;

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

            // For Entity Framework
            builder.Services.AddDbContext<VinodrillDBContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("VinoDrillDbContext")));
            builder.Services.AddDbContext<AuthDbContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("VinoDrillDbContext")));

            // For Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

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
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDataRepository<Activite>, ActiviteManager>();
            builder.Services.AddScoped<IDataRepository<Adresse>, AdresseManager>();
            builder.Services.AddScoped<IDataRepository<Partenaire>,PartenaireManager>();
            builder.Services.AddScoped<IDataRepository<Destination>, DestinationManager>();
            builder.Services.AddScoped<IDataRepository<Effectue>, EffectueManager>();
            builder.Services.AddScoped<IAvisRepository, AviManager>();
            builder.Services.AddScoped<ISejourRepository, SejourManager>();


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

            app.UseHttpsRedirection();

            // Authentication & Authorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}