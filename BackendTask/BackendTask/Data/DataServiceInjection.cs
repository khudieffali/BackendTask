using BackendTask.Data.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace BackendTask.Data
{
    public static class DataServiceInjection
    {

        public static IServiceCollection DataServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("TaskDB");
            services.AddDbContext<DbContext, TaskContext>(cfg =>
            {
                cfg.UseSqlServer(connectionString,
                    options =>
                    {
                        options.MigrationsHistoryTable("Migrations");
                    });
            });
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
                        ValidIssuer = config["Token:Issuer"],
                        ValidAudience = config["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:SecurityKey"])),
                        ClockSkew= TimeSpan.Zero,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonSerializer.Serialize(new { message = "Zəhmət olmasa qeydiyyatdan keçin və ya daxil olun." });
                            await context.Response.WriteAsync(result);
                        }
                    };
                });
            services.AddAuthorization();
            services.AddHttpClient();
            return services;
        }
    }
}
