using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Providers.GitPath.Interface;
using Providers.GitPath;
using SoftPlan.Fianceiro.Domain.Services.Interfaces;
using SoftPlan.Fianceiro.Domain.Services;

namespace SoftPlan.WebApp.CalculoJuros.Api
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

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Calculo Juros Compostos",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1 para calcular os juros compostos de uma aplicação",
                        Contact = new OpenApiContact
                        {
                            Name = "João Nascimento",
                            Url = new Uri("https://github.com/joaoBrRj91/desafio-softplan")
                        }
                    });
            });


            services.AddScoped<ITaxaJurosAplicacaoService, TaxaJurosAplicacaoService>();
            services.AddScoped<IGitDiretorioRemotoService, LibGit2SharpService>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Environment.SetEnvironmentVariable("API_TAXA_JUROS_URL", "http://localhost:5000");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculo Juros Compostos V1");
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
