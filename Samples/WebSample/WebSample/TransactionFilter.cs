namespace WebSample.UI
{
    using System;
    using System.Web.Mvc;
    using Sparks.Persistence;
    using StructureMap;

    public class TransactionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();
            unitOfWork.Initialize();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
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
    }
}