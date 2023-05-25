
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.ServiceConfiguration;
using QueueManager.Application.Services;
using QueueManager.Infrastructure.DataAccess;
using QueueManager.Infrastructure.DbConfiguration;
using QueueManager.Infrastructure.Implementation.common;
using System.Text;

namespace QueueManager.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration config = builder.Configuration;
            // Add services to the container.

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(config);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]??""))
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = (context) =>
                    {
                        if(context.Exception.GetType()==typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("IS_TOKEN_EXPIRED", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme()
                    {
                       Reference=new OpenApiReference()
                       {
                           Id="Bearer",
                           Type=ReferenceType.SecurityScheme
                       }
                    },
                    new List<string>()
                } });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}