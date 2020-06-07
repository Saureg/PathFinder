using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PathFinder.Extensions
{
    public static class HtmlHelperExtension
    {
        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, string actions,
            string @class = "active")
        {
            var currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            var currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;

            IEnumerable<string> acceptedActions = (actions ?? currentAction)?.Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController)?.Split(',');

            return acceptedActions!.Contains(currentAction) && acceptedControllers!.Contains(currentController)
                ? @class
                : string.Empty;
        }
    }
}