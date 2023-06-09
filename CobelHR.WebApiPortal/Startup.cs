using EssentialCore.Tools.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssentialCore.ExtenssionMethod;
using EssentialCore.Tools.Middleware;

namespace CobelHR.WebApiPortal
{
    public class Startup
    {
        readonly string corsName = "CorsName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            EssentialCore.Tools.Configuartion.ConfigurationService.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(a =>
            {
                a.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRCore . WebApiPortal", Version = "v1" });

            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(corsName, builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

            var tokenOption = Configuration.GetSection("TokenConfig").Get<TokenConfig>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOption.Issuer,
                        ValidAudience = tokenOption.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityExtension.CreateSecurityKey(tokenOption.SecurityKey)
                    };
                });

            CobelHR.Services.ServiceProvider.Load(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRCore.WebApiPortal v1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(corsName);


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseXCoreAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
