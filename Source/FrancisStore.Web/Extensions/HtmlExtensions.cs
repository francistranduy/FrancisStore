using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrancisStore.Web.Extensions
{
    public static class HtmlExtensions
    {
        public static bool IsActive(this HtmlHelper html, string controller, string action)
        {
            //Parameters is null or empty
            if (string.IsNullOrEmpty(controller) || string.IsNullOrEmpty(action))
                return false;

            //Controller is not match
            if (!controller.Equals(html.ViewContext.RouteData.GetRequiredString("controller"), StringComparison.InvariantCultureIgnoreCase))
                return false;

            //Action is not match
            if (!action.Equals(html.ViewContext.RouteData.GetRequiredString("action"), StringComparison.InvariantCultureIgnoreCase))
                return false;

            return true;
        }
    }
}