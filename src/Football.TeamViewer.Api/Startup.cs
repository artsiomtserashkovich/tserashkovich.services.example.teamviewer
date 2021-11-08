using Football.TeamViewer.Api.Filters;
using Football.TeamViewer.Application.Bootstrapping;
using Football.TeamViewer.Persistence.Bootstrapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Football.TeamViewer.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabaseSupport()
                .AddMediatrSupport()
                .AddValidationSupport();
            
            // TODO: add HealthCheck endpoint : /api/healthCheck
            // Add healthCheck for Database

            services.AddMvcCore(options =>
            {
                options.Filters.Add<ExceptionsFilter>();
            });
            
            // TODO: check if it's enough for JWT authorization
            // If not introduce the policy handler
            // The main purpose of policy handler will be checking role and if all required claims are presented
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(_configuration.GetSection("AzureAd"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                // TODO: provide configuration from configuration file
                // FeatureToggle can be introduced
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Football.TeamViewer.Api", Version = "v1"});
            });
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football.TeamViewer.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}