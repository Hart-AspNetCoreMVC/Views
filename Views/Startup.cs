using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Views.Infrasructure;

namespace Views
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //MVCViewOptions defines ViewEngines prop containing list of viewEngines. Razor is already added by the AddMvc method (to remove it add -- options.ViewEngines.Clear() above the insert line.
            //here we have inserted out custom DebugDataViewEngine into the list
            //when MVC received ViewResult from an action metho -- it calls the FindView method of every engine until it finds a match
            //the match triggers the .found method and returns a ViewEngineResult -- in this case, is a DebugDataView
//            services.Configure<MvcViewOptions>(options =>
//            {
//                options.ViewEngines.Insert(0, new DebugDataViewEngine());
//            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
