using System.Linq;
using System.Threading.Tasks;
using Api.Infrastructure;
using Api.Repositories;
using BeatPulse;
using BeatPulse.Core;
using BeatPulse.Core.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHeroesRepository, HeroesRepository>();
            services.AddDbContext<HeroesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("heroesConnection")));
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddBeatPulse(setup =>
            {
                
                setup.AddApplicationInsightsTracker();
                setup.AddLiveness("external", opt =>
                {
                    opt.UsePath("external");
                    opt.UseLiveness(new ActionLiveness((__) => Task.FromResult(LivenessResult.Healthy())));
                });
           
            });
            services.AddSingleton<IBeatPulseAuthenticationFilter>(new ApiKeyAuthenticationFilter(Configuration["LivenessAPIKey"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var corsValues = Configuration.GetSection("Cors")
                                .GetChildren().Select(a => a.Value).Where(a => !string.IsNullOrWhiteSpace(a)).ToArray();

            app.UseCors(builder =>
                builder.WithOrigins(corsValues)
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            
            app.UseMvcWithDefaultRoute();
        }
    }
}