using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

//Common convention to place the extension in the same namestace as the object it extens
//it that way its always available on the object
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        //public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, ApplicationEnvironment env)
        //{
        //    var path = Path.Combine(env.ApplicationBasePath, "node_modules");
        //    var provider = new PhysicalFileProvider(path);
        //    var options = new StaticFileOptions();
        //    options.RequestPath = "/node_modules";
        //    options.FileProvider = provider;

        //    app.UseStaticFiles(options);
        //    return app;
        //}

        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var path = Path.Combine(env.ContentRootPath, "node_modules");
            var provider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;

            app.UseStaticFiles(options);
            return app;
        }
    }
}
