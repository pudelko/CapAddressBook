using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestAddressBook.Helpers;


namespace TestAddressBook
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EfTools.RebuildDataBase();

            #if DEBUG
            GlobalFilters.Filters.Add(new ActionFilter());
            #endif

            GlobalFilters.Filters.Add(new ExceptionFilter());         
            
        }

        protected void Application_BeginRequest()
        {
            #if DEBUG
            Debug.WriteLine("On begin request", "App state");
            #endif
        }
    }
}
