using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                //this route will now match any URL, irrespective og the number of segments it contains or the value of any of those segments
                //if URL contains additional segments, they are all assigned to the catchall variable
                //example of work

                //Segments              Example URL                         Maps To
                //0                     /                                   controller = Home action = Index 
                //1                     /Customer                           controller = Customer action = Index 
                //2                     /Customer/List                      controller = Customer action = List 
                //3                     /Customer/List/All                  controller = Customer action = List id = All 
                //4                     /Customer/List/All/Delete           controller = Customer action = List id = All catchall = Delete 
                //5                     /Customer/List/All/Delete/Perm      controller = Customer action = List id = All catchall = Delete/Perm
                routes.MapRoute( name: "MyRoute", 
                    template: "{controller=Home}/{action=Index}/{id?}/{*catchall}" );
            } );
        }
    }
}
