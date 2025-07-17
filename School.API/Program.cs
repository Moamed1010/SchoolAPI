
using FluentValidation;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School.Core;
using School.Core.Features.Department.Commands.Validators;
using School.Core.Features.Department.Quaries.Models;
using School.Core.Middleware;
using School.service;
using Shcool.Infrustructure;
using Shcool.Infrustructure.Data;
using System.Globalization;

namespace School.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection")));
            #region Dependency Injection
            builder.Services.AddInfrustructureDependencies()
                .AddSeeviceDependencies()

                .AddCoreDependencies();
            builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetDepartmentListQuery).Assembly));
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddServiceRegistration();

            #region Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddValidatorsFromAssemblyContaining<EditDepartmentValidator>();


            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("de-DE"),

                };


                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            #endregion

            #region allow cors
            var CORS = "_cors";



            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORS,
                    policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyMethod();
                        policy.AllowAnyHeader();


                    });
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #region Localization
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseCors(CORS);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
