using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Trinca.Churras.WebApp.Dados;
using Trinca.Churras.WebApp.Dados.LiteDB;
using Trinca.Churras.WebApp.Services;
using Trinca.Churras.WebApp.Services.Handlers;

namespace Trinca.Churras.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddControllersAsServices();

            // aqui indico ao AspNetCore como resolver 
            // as instâncias das Interfaces de acesso a dados
            //---------------------------------------------------

            services.AddTransient<IChurrasDao, ChurrasDaoComLiteDB>();
            services.AddTransient<IChurrasService, DefaultChurrasService>();
            services.AddSingleton<LiteDbContext>();


            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            //app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=churras}/{id?}");
            });
        }
    }
}
