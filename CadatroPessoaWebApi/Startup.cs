using CadatroPessoaWebApi.Models;
using CadatroPessoaWebApi.Repositories;
using CadatroPessoaWebApi.Repositories.Dao;
using CadatroPessoaWebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadatroPessoaWebApi
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
            
            //services.AddDbContext<cadastropessoaContext>(opt => opt.UseInMemoryDatabase("PessoaList"));

            services.AddScoped<IService<Pessoa>, PessoaService>();
            services.AddScoped<IRepository<Pessoa>, PessoaRepository>();
            services.AddScoped<IDao<Pessoa>, Dao<Pessoa>>();

            services.AddScoped<IService<Endereco>, EnderecoService>();
            services.AddScoped<IRepository<Endereco>, EnderecoRepository>();
            services.AddScoped<IDao<Endereco>, Dao<Endereco>>();

            services.AddScoped<IService<Telefone>, TelefoneService>();
            services.AddScoped<IRepository<Telefone>, TelefoneRepository>();
            services.AddScoped<IDao<Telefone>, Dao<Telefone>>();

            services.AddScoped<IService<TelefoneTipo>, TelefoneTipoService>();
            services.AddScoped<IRepository<TelefoneTipo>, TelefoneTipoRepository>();
            services.AddScoped<IDao<TelefoneTipo>, Dao<TelefoneTipo>>();

            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadatroPessoaWebApi", Version = "v1" });
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadatroPessoaWebApi v1"));
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
