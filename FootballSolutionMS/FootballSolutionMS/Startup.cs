using FootballDataAccess.Database;
using FootballSolutionMS.Extensions;
using KafkaService.Services.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballSolutionMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string connString = Configuration["Connection_String"];
            // services.AddDbContext<FootballDbContext>(options => options.UseSqlServer(connString));
            services.AddDbContext<FootballDbContext>(options => options.UseOracle(connString));
            services.ResolveServices();

            services.Configure<KafkaOptions>(Configuration.GetSection("KafkaOptions"));
            services.ResolveKafka();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
