using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Messages.Web.Navigation
{
    public static class RouteHelper
    {
        public static string ChangePage(this UrlHelper urlHelper, int page)
        {
            var newRouteValues = new RouteValueDictionary();

            var routeValues = urlHelper.RequestContext.RouteData.Values;
            foreach (var routeValue in routeValues)
            {
                if(routeValue.Key != "page")
                {
                    newRouteValues.Add(routeValue.Key, routeValue.Value);
                }
            }

            var queryString = urlHelper.RequestContext.HttpContext.Request.QueryString;
            foreach (var key in queryString.AllKeys)
            {
                if (key != "page")
                {
                    newRouteValues.Add(key, queryString[key]);
                }
            }

            if(page > 1)
            {
                newRouteValues.Add("page", page);
            }

            return urlHelper.Action(
                routeValues["action"].ToString(),
                routeValues["controller"].ToString(),
                newRouteValues
            );
        }
    }
}