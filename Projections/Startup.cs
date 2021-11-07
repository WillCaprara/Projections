using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projections.Services;
using Projections.Services.Implementation;
using Projections.Repositories;
using Projections.Repositories.Implementation;
using Projections.DbContexts;
using Microsoft.EntityFrameworkCore;
using Projections.Helpers;
using System.Collections.Generic;

namespace Projections
{
    public class Startup
    {
        private readonly string AllowedOrigins = "_myAllowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed(origin => true);
                                  });
            });

            services.AddControllers();

            //
            services.AddDbContext<ProjectionsContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ProjectionsConnection")));

            //Services
            services.AddTransient<IProjectionService, ProjectionService>();
            services.AddTransient<IActualService, ActualService>();

            //Repositories
            services.AddTransient<IProjectionRepository, ProjectionRepository>();
            services.AddTransient<IActualRepository, ActualRepository>();

            //Helpers
            services.AddScoped<IXmlHelper, XmlHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();            

            app.UseRouting();

            app.UseCors(AllowedOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
