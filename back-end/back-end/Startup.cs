using AutoMapper;
using back_end.Controllers;
using back_end.Filtros;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace back_end
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
            services.AddAutoMapper(typeof(Startup));

            //para guardar en azure storage.
            //services.AddTransient<IAlmacenadorArchivos, AlmacenadorAzureStorage>();

            //guardar local
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();

            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("defaultConnection"),
            sqlServer => sqlServer.UseNetTopologySuite()));

            services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

            services.AddCors(options => {
                var frontendURL = Configuration.GetValue<string>("frontend_url");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[] { "cantidadTotalRegistros" });
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            
            //Existen tres maneras tres tiempos de vida o ciclos de vida que pueden tener un servicio que son 
            //Transient, Scope, Singleton.

            //Transient, que es el que estamos utilizando.
            //Es el tiempo más corto de vida que le podemos dar a un servicio.
            //Y significa que cada vez que pidamos.
            //Por ejemplo, en este caso una instancia del servicio de IRepositorio, vamos a tener una nueva instancia
            //de este RepositorioEnMemoria.
            //No importa que en una misma petición HTTP
            //distintas clases soliciten el servicio IRepositorio.
            //Se les va a entregar una instancia distinta al RepositorioEnMemoria.

            //Otro caso que tenemos es Scope
            //Cuando hablamos de scope nos referimos a que el tiempo de vida de la clase instanciada va a ser durante
            //toda la petición http.

            //Singleton el cual sirve para indicar que el tiempo de vida de la instancia RepositorioEnMemoria
            //en este caso de la instancia del servicio va a ser durante todo el tiempo de ejecución de
            //la aplicación, lo que quiere decir que distintos clientes van a compartir la misma instancia de la
            //clase RepositorioEnMemoria.

            services.AddControllers(options => {
                options.Filters.Add(typeof(FiltroDeExcepcion));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "back_end", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //tuberia de procesos. Middleware.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {             
            //los middleware que empiezan con use no detienen el proceso.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "back_end v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
