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
                //simple constraint that limits the URLs that a route will match
                //The int constraint only allows the URL pattern to match segments whose value can be parsed to an integer value
                //example of work
                // Example URL                          Maps To
                // /                                    controller = Home  action = Index  id = null 
                // /Home/CustomVariable/Hello           No match—id segment cannot be parsed to an int value. 
                // /Home/CustomVariable/1               controller = Home  action = CustomVariable  id = 1 
                // /Home/CustomVariable/1/2             No match—too many segments
                routes.MapRoute( name: "MyRoute", 
                    template: "{controller=Home}/{action=Index}/{id:int?}" );
            } );
        }
    }
}
