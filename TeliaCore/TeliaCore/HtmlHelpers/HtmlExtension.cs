using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TeliaCore.Models;


namespace TeliaCore.HtmlHelpers
{
    public static class HtmlExtensions
    {
        public static void AddContactToList(ref List<int> contactIds, int id)
        {
             contactIds.Add(id);
        }

        public static MvcHtmlString ActionTopMenuItem(this HtmlHelper htmlHelper, String linkText,
            String actionName, String controllerName)
        {
            var tag = new TagBuilder("li");

            if (htmlHelper.ViewContext.RequestContext
                .IsCurrentRoute(null, controllerName, actionName))
            {
                tag.AddCssClass("selected");
            }

            tag.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToString();

            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString ActionSideMenuItem(this HtmlHelper htmlHelper, String linkText,
       String actionName, String controllerName)
        {
            var tag = new TagBuilder("li");
            var tagSpan = new TagBuilder("span");

            if (htmlHelper.ViewContext.RequestContext
                .IsCurrentRoute(null, controllerName, actionName))
            {
                tag.AddCssClass("foldout");
            }

            
            tag.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToString();

            return MvcHtmlString.Create(tag.ToString());
        }
    }

    public static class RequestExtensions
    {
        public static bool IsCurrentRoute(this RequestContext context, String areaName,
            String controllerName, params String[] actionNames)
        {
            var routeData = context.RouteData;
            var routeArea = routeData.DataTokens["area"] as String;
            var current = false;

            if (((String.IsNullOrEmpty(routeArea) && String.IsNullOrEmpty(areaName)) ||
                  (routeArea == areaName)) &&

                 ((String.IsNullOrEmpty(controllerName)) ||
                  (routeData.GetRequiredString("controller") == controllerName)) &&

                 ((actionNames == null) ||
                   actionNames.Contains(routeData.GetRequiredString("action"))))
            {
                current = true;
            }

            return current;
        }

    }

    public static class UrlExtensions
    {
        public static bool IsCurrent(this UrlHelper urlHelper, String areaName,
            String controllerName, params String[] actionNames)
        {
            return urlHelper.RequestContext.IsCurrentRoute(areaName, controllerName, actionNames);
        }

        public static string Selected(this UrlHelper urlHelper, String areaName,
            String controllerName, params String[] actionNames)
        {
            return urlHelper.IsCurrent(areaName, controllerName, actionNames)
                ? "selected" : String.Empty;
        }
    }
}