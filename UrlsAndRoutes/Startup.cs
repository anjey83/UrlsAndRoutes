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
                //mixed segments static and variable
                //matches any two-segment URL where the first letter starts with 'X'
                routes.MapRoute("", "X{controller}/{action}");

                routes.MapRoute( name: "default",
                                 template: "{controller=Home}/{action=Index}" ); //provides both pattern and default behaviour without any segment
                //By providing def vals for both the conntroller and action, the route will match urls that have zero, one or two segments
                // /                controller=Home         action=Index
                // /Customer        controller=Customer     action=Index
                // /Customer/List   controller=Customer     action=List
                // /Customer/List/All No match—too many segments

                //http://domain.com.Public/Home/Index app need to match url that are prefixed by Public
                //this pattern match only urls that contains 3 segments, first of them must be 'Public'
                routes.MapRoute(name:"",
                                template:"Public/{controller=Home}/{action=Index}");

            } );
        }
    }
}
