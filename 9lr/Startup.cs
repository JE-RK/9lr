using Microsoft.AspNetCore.Builder;
using integtest.Classes;
using integtest.Interfaces;
using Npgsql;

namespace _9lr
{
    public static class Startup
    {
        //public void Configure(IApplicationBuilder app)
        //{
        //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //}
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddScoped<NpgsqlConnection>(connection => new NpgsqlConnection("Server=localhost;Port=5432;Username=postgres;Password=123098;Database=Triangle"));
            services.AddTransient<ITriangleProvider, TriangleProvider>();
            services.AddTransient<ITriangleService, TriangleService>();
            services.AddTransient<ITriangleValidateService, TriangleValidateService>();
        }
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
        }
    }
}
