using System;
using System.Web.Mvc;
using System.Web.Routing;
using Sparks.Persistence;
using StructureMap;
using WebSample.UI.Configs;

namespace WebSample.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();
            unitOfWork.Initialize();

        }

        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();

            try
            {
                unitOfWork.Commit();
                unitOfWork.Dispose();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        protected void Application_Start()
        {
            StructureMapBootstrapper.Execute();
            
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}