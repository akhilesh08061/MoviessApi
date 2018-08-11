using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using moviesApi.Models;

namespace moviesApi
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
            services.AddMvc();
            services.AddDbContext<MoviesDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));


            //https redirection

            services.AddHttpsRedirection(Options => { Options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                Options.HttpsPort = 5001;
            });


            //add identity server authentication and authorization

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(Options =>
                {
                    Options.Authority = "http://localhost:5004";
                    Options.RequireHttpsMetadata = false;
                    Options.ApiName = "moviesApi";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
