using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.Contexts;
using Repository.IRepositories;
using Repository.Repositories;
using Repository.Repository;
using Service.IServices;
using Service.Services;

namespace Teste
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().AddJsonOptions(options => { });

            ConfiguracoesContexto(services);
            ConfiguracoesServicos(services);
            ConfiguracoesRepositorios(services);
            ConfiguracaoCors(services);
            ConfiguracaoAutoMapper(services);
        }

        private void ConfiguracaoCors(IServiceCollection services)
        {
            //formatando o CORS para aceitar requisições de qualquer endereço
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        private static void ConfiguracoesServicos(IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
        }

        private static void ConfiguracoesRepositorios(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
        }


        private static void ConfiguracoesContexto(IServiceCollection services)
        {
            //injetando contexto do banco de dados
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<Context>()
                    .BuildServiceProvider();
        }

        private void ConfiguracaoAutoMapper(IServiceCollection services)
        {
            //Configurando o auto mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mappingConfig.CompileMappings();

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
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

            app.UseCors("SiteCorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "/api/{controller}/{action}/{id?}");
            });
        }
    }
}
