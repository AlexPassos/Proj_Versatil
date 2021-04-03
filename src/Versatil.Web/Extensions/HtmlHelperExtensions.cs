using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string GetActiveRoute(this IHtmlHelper htmlHelper, string action, string controller, string area = "", bool ignoreAction = false)
        {
            var isActiveRoute = IsActiveRoute(htmlHelper, action, new[] { $"{controller}" }, area, ignoreAction);
            return isActiveRoute ? "active" : "";
        }

        public static string GetActiveRoute(this IHtmlHelper htmlHelper, string action, string[] controllers, string area = "", bool ignoreAction = false)
        {
            var isActiveRoute = IsActiveRoute(htmlHelper, action, controllers, area, ignoreAction);
            return isActiveRoute ? "active" : "";
        }

        public static string GetActiveRouteSubMenu(this IHtmlHelper htmlHelper, string controller, string area = "")
        {
            var isActiveRoute = IsActiveRoute(htmlHelper, "", new[] { $"{controller}" }, area, true);
            return isActiveRoute ? "menu-open" : "";
        }

        public static string GetActiveRouteSubMenu(this IHtmlHelper htmlHelper, string[] controllers, string area = "")
        {
            var isActiveRoute = IsActiveRoute(htmlHelper, "", controllers, area, true);
            return isActiveRoute ? "menu-open" : "";
        }

        private static bool IsActiveRoute(IHtmlHelper htmlHelper, string action, string[] controllers, string area, bool ignoreAction)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeController = (string)routeData.Values["controller"];
            var routeArea = (string)routeData.Values["area"];

            bool actionOn = string.Equals(action, routeAction, StringComparison.OrdinalIgnoreCase);
            bool areaOn = string.Equals(area, routeArea, StringComparison.OrdinalIgnoreCase);
            bool controllerOn = controllers != null && controllers.Any(x => x.Equals(routeController, StringComparison.OrdinalIgnoreCase));

            if (ignoreAction && string.IsNullOrEmpty(area))
                return controllerOn;

            if (!ignoreAction && !string.IsNullOrEmpty(area))
                return controllerOn && areaOn;

            if (!string.IsNullOrEmpty(area))
                return actionOn && controllerOn && areaOn;

            return actionOn && controllerOn;
        }
    }
}