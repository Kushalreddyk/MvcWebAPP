﻿using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LoggerFactory;

namespace solution2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            // Log the exception
            LoggerFactory.Factory.LogException(exception);

            // Redirect to the error page
            Server.ClearError();
            Response.Redirect("/Error");
        }
    }
}
