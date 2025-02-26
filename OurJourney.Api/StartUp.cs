﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OurJourney.Api.Extensions;
using OurJourney.Api.Utils;
using OurJourney.Application.Common.Settings;
using Serilog;

namespace OurJourney.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomAuthentication(Configuration);
            services.AddCustomAuthorization();
            services.AddCustomMVC();
            services.AddCustomServices();
            services.AddCustomHealthCheck();
            services.AddCustomOptions(Configuration);
            services.AddLayersDependencyInjections(Configuration);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "FinanceTec API",
                    Version = "v1"
                });
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = false;
            });


            var container = new ContainerBuilder();
            container.Populate(services);

            ApplicationContainer = container.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppSettings appSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("../swagger/v1/swagger.json", "FinanceTec API");
                });
            }
            app.UseSerilogRequestLogging();
            app.UseResponseCompression();
            app.UserCustomExceptionHandler(env);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(Constants.CorsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            //var applicationDisplayName = configurationManager.GetValue<string>(Constants.ApplicationDisplayName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapGet(Constants.WelcomePath, async context =>
                {
                    await context.Response.WriteAsync(string.Format(Constants.WelcomeAPI, appSettings.ApplicationDisplayName));
                });
                endpoints.MapHealthChecks(Constants.HealthPath, new HealthCheckOptions()
                {
                    AllowCachingResponses = false,
                    ResponseWriter = ConfigureExtensions.WriteResponseHealth
                });
                endpoints.MapHealthChecks(Constants.ExternalHealthPath, new HealthCheckOptions()
                {
                    AllowCachingResponses = false,
                    ResponseWriter = ConfigureExtensions.WriteResponseHealth
                });
            });
        }
    }
}
