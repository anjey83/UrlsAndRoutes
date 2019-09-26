﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.Configure<RouteOptions>( options =>
                 options.ConstraintMap.Add( "weekday", typeof( WeekDayConstraint ) ) );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc( 
                routes => 
                {
                    //This route will match a URL only if the id segment is absent (such as /Customer/List) 
                    //or if it matches one of the days of the week defined in the constraint class (such as /Customer/List/Fri).
                    routes.MapRoute( name: "MyRoute",
                        template: "{controller=Home}/{action=Index}/{id:weekday?}" );
                } );
        }
    }
}
