using System;
using System.Text;
using Application.Token;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  
            #region JSON

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            #endregion
            
            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API_Bem_Promotora",
                    Version = "v1",
                    Description = "API construída para um projeto de avaliação de estágio na Empresa Bem Promotora. (Bearer)",
                    Contact = new OpenApiContact
                    {
                        Name = "M. David Sousa",
                        Email = "issac.newton.1643.apple@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/marcos-david-almeida-de-sousa-499449207/")
                    },
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor, utilize Bearer <TOKEN>",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
            });

            #endregion

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Treina_Cliente, Treina_ClienteDTO>().ReverseMap();
                cfg.CreateMap<Treina_Proposta, Treina_PropostaDTO>().ReverseMap();
                cfg.CreateMap<Treina_Usuario, Treina_UsuarioDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region DI

            services.AddSingleton(d => Configuration);
            services.AddDbContext<ManagerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
            services.AddScoped<ITreina_ClienteRepository, Treina_ClienteRepository>();

            services.AddScoped<ITreina_PropostaService, Treina_PropostaService>();
            services.AddScoped<ITreina_PropostaRepository, Treina_PropostaRepository>();

            services.AddScoped<ITreina_UsuarioService, Treina_UsuarioService>();
            services.AddScoped<ITreina_UsuarioRepository, Treina_UsuarioRepository>();

            services.AddScoped<ITreina_ConveniadaService, Treina_ConveniadaService>();
            services.AddScoped<ITreina_ConveniadaRepository, Treina_ConveniadaRepository>();

            services.AddScoped<ITreina_CalculoJurosService, Treina_CalculoJurosService>();
            services.AddScoped<ITreina_CalculoJurosRepository, Treina_CalculoJurosRepository>();

            services.AddScoped<ITreina_SituacaoService, Treina_SituacaoService>();
            services.AddScoped<ITreina_SituacaoRepository, Treina_SituacaoRepository>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            // sevices.AddTransient<> 
            // Uma instâcia em cada ponto do code. ex.: Se uma requisição precisar de 3 construtores, ele cria 3 instâncias.

            // sevices.AddSingleton<>  
            // Uma instâcia em todo o ciclo da aplicação.

            // sevices.AddScoped<>  
            // Uma instâcia por requisição.

            #endregion

            #region Jwt

            var secretKey = Configuration["Jwt:Key"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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

            app.UseCors();  // Entre UseHttpsRedirection() e app.UseAuthentication()

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
