namespace CrediAgil.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Microsoft.EntityFrameworkCore;
    using DM.Api.BaseDeDatos.Context;
    using Soporte.Api.Utilidades;
    using BM.Api.Cliente;
    using DM.Api.Cliente;
    using DM.Api.Cupo;
    using BM.Api.Credito;
    using DM.Api.Credito;
    using BM.Api.Maestros;
    using DM.Api.Maestros.Departamento;
    using DM.Api.Maestros.Pais;
    using DM.Api.Maestros.Ciudad;
    using DM.Api.Maestros.TipoDni;
    using DM.Api.Maestros.FrecuenciaPago;

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
            //Configuration Entity
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CrediAgilContext>(options => options.UseSqlServer(connection));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            //Configuration for Automapper
            var config = new AutoMapper.MapperConfiguration(c => {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //Cliente
            services.AddScoped<IBMCliente, BMCliente>();
            services.AddScoped<IDMCliente, DMCliente>();
            //Credito
            services.AddScoped<IBMCredito, BMCredito>();
            services.AddScoped<IDMCredito, DMCredito>();

            //Cupo
            services.AddScoped<IDMCupo, DMCupo>();

            //Maestros 
            services.AddScoped<IBMMaestro, BMMaestro>();
            services.AddScoped<IDMDepartamento, DMDepartamento>();
            services.AddScoped<IDMPais, DMPais>();
            services.AddScoped<IDMCiudad, DMCiudad>();
            services.AddScoped<IDMTipoDni, DMTipoDni>();
            services.AddScoped<IDMFrecuenciaPago, DMFrecuenciaPago>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrediAgil.Api", Version = "v1" });
            });

            services.AddDbContext<CrediAgilContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CrediAgilApiContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrediAgil.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsApi");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
