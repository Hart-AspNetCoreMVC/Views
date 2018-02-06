using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
//required directives
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Primitives;

namespace Views.Infrasructure
    //Manually creates a View(forming a ViewEngineResult), which implements the IView as required
{   //Code below receivs the ViewContext object, sets the content header, inits a new string builder object and writes lines to it -- adding some of the data stored
    // in the ViewContect object -- RouteData and ViewData
    public class DebugDataView : IView
    {
        public string Path => String.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("----Routing Data----");
            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            sb.AppendLine("----View Date___");
            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
            await context.Writer.WriteAsync(sb.ToString());
        }
    }
}
