using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace DZzzz.Learning.Core.Views.Infrasctructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            // we need to specify locations where we need to try found a view
            return ViewEngineResult.NotFound(viewPath, new[] { "(Debug View Engine - GetView)" });
        }

        // this method is called if GetView isn`t returned any view
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (viewName == "DebugData")
            {
                return ViewEngineResult.Found(viewName, new DebugDataView());
            }

            return ViewEngineResult.NotFound(viewName, new[] { "(Debug View Engine - FindView)" });
        }
    }
}