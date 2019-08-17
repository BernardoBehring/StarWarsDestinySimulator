using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsDestiny.API.Graph.Schema;
using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Common.Repository.Interfaces;
using StarWarsDestiny.Common.Service.Impl;
using StarWarsDestiny.Common.Service.Interfaces;
using StarWarsDestiny.Repository.Context;
using StarWarsDestiny.Service.Impl;
using StarWarsDestiny.Service.Interfaces;

namespace StarWarsDestiny.API
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
            services.AddDbContext<StarWarsDestinyContext>(options =>
                options.UseSqlServer(
                    "Data Source=localhost\\MSSQLSERVER01; DataBase=StarWarsDestiny;Integrated Security=True"));
            InjectDependencies(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<StarWarsDestinySchema>();
            
            services.AddGraphQL(x => { x.ExposeExceptions = true; }).AddGraphTypes(ServiceLifetime.Scoped);
        }

        private static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IDieService, DieService>();
            services.AddScoped<IDiceFaceService, DiceFaceService>();
            
            services.TryAddScoped(typeof(IReadWriteRepository<,>), typeof(ReadWriteRepository<,>));
            services.TryAddScoped(typeof(IReadWriteService<,>), typeof(ReadWriteService<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphQL<StarWarsDestinySchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseMvc();
        }
    }
}
