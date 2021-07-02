using System;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Cobrancas.Domain.Interfaces;
using Cobrancas.Service.Services;
using Cobrancas.Domain.Entities;
using Cobrnacas.Domain.Interfaces;
using Cobrnacas.Infra.Data.Repositories;
using Cobrancas.Infra.Data.Database;


namespace Cobrancas.Application
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
            services.AddControllers();

            services.Configure<CobrancasDatabaseSettings>(
                Configuration.GetSection(nameof(CobrancasDatabaseSettings)));

            services.AddSingleton<ICobrancasDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CobrancasDatabaseSettings>>().Value);

            services.AddScoped<IBaseService<Cobranca>, BaseService<Cobranca>>();
            services.AddScoped<IBaseRepository<Cobranca>, BaseRepository<Cobranca>>();

            services.AddSingleton<MongoDatabase<Cobranca>>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "swagger", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger v1"));
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
