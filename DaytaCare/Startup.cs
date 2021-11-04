using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DaytaCare.Data;
using DaytaCare.Models.Identity;
using DaytaCare.Services;
using DaytaCare.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace DaytaCare
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DaytaCareDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(connectionString);
            });


            //Identity!!!
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //Configure password requirements, etc.
                options.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<DaytaCareDbContext>();

            services.AddScoped<IUserService, IdentityUserService>();
            services.AddScoped<JwtService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtService.GetValidationParameters(Configuration);
            });

            services.AddScoped<IDaycareRepository, DatabaseDaycareRepository>();

            services.AddScoped<IParentRepository, DatabaseParentRepository>();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Dayta Care",
                    Version = "v1",
                });

                options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>(true, "JWT");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Dayta Care");
                options.RoutePrefix = "docs";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>

            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    var req = context.Request;
                    var res = context.Response;

                    context.Response.Redirect("/docs");
                });
            });
        }
    }
}
