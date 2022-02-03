using BusStation.Contracts;
using BusStation.Data;
using BusStation.Data.DataTransferObjects.Admin;
using BusStation.WebApi.ActionFilters;
using BusStation.WebApi.Managers;
using BusStopStation.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace BusStation.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .WithExposedHeaders("pagination"));
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = true;
                options.AuthenticationDisplayName = null;
                options.ForwardClientCertificate = true;
            });

        public static void ConfigureAuthenticationManager(this IServiceCollection services) =>
            services.AddScoped<IAutenticationManager, AuthenticationManager>();

        public static void ConfigureRoleManager(this IServiceCollection services) =>
            services.AddScoped<RoleManager<IdentityRole>>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("BusStationDbConnection"), builder =>
              builder.MigrationsAssembly("BusStation.Data")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Admin>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);

            builder.AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = configuration.GetSection("SECRET").Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CodeMazeSecretKey"))
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Bus Station Service API",
                    Version = "v1",
                    Description = "Bus Station Service Web API",
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureValidationAttributes(this IServiceCollection services)
        {
            services.AddScoped<AdminValidateAttribute>();
            services.AddScoped<BusStopValidateAttribute>();
            services.AddScoped<BusValidateAttribute>();
            services.AddScoped<RouteValidateAttribute>();
            services.AddScoped<TripValidateAttribute>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Startup));

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 5096;
                options.UseCaseSensitivePaths = true;
            });
    }
}
