using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.Infrasructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        //BUILDING A CUSTOM VIEW ENGINE
        //View engines implement the IViewEngine inerface; which consists of 2 meths -- GetView and FindView
        //View engine's job is to translate requests for views into a ViewEngineResult
        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, new string[]
            {
                "(Debug View Engine - GetView)"
            });
        }

        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
            {
                if (viewName == "DebugData")
                {
                    return ViewEngineResult.Found(viewName, new DebugDataView()); 
                }else
                    {
                        return ViewEngineResult.NotFound(viewName, new string[] {"(Debug View Engine - FindView)"});
                    }
               }
        }
    }

