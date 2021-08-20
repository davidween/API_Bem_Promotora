using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Service.DataTransferObject;
using Service.Interfaces;
using Service.Services;

namespace Application
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application", Version = "v1" });
            });

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Treina_Cliente, Treina_ClienteDTO>().ReverseMap();
                cfg.CreateMap<Treina_Proposta, Treina_PropostaDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region DI

            services.AddSingleton(d => Configuration);
            services.AddDbContext<ManagerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
            services.AddScoped<ITreina_ClienteService, Treina_ClienteService>();
            services.AddScoped<ITreina_ClienteRepository, Treina_ClienteRepository>();
            services.AddScoped<ITreina_PropostaService, Treina_PropostaService>();
            services.AddScoped<ITreina_PropostaRepository, Treina_PropostaRepository>();

            // sevices.AddTransient<> 
            // Uma instâcia em cada ponto do code. ex.: Se uma requisição precisar de 3 construtores, ele cria 3 instâncias.

            // sevices.AddSingleton<>  
            // Uma instâcia em todo o ciclo da aplicação.

            // sevices.AddScoped<>  
            // Uma instâcia por requisição.


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1"));
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
