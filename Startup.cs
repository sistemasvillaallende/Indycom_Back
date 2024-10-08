using Microsoft.JSInterop;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Web_Api_IyC.Services;

namespace Web_Api_IyC
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

            });

            // configure DI for application services
            services.AddScoped<IIndycomServices, IndycomServices>();
            services.AddScoped<ICtasctes_indycomServices, Ctasctes_indycomServices>();
            services.AddScoped<ITarjetasServices, TarjetasServices>();
            services.AddScoped<IBadecServices, BadecServices>();
            services.AddScoped<IConceptos_iycService, Conceptos_iycService>();
            services.AddScoped<IDescadic_x_iycService, Descadic_x_iycService>();

            //
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
                });
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

