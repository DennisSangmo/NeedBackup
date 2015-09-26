using System.Web.Mvc;
using NeedBackup.Core.IoC;
using NHibernate;

namespace NeedBackup.Web.MVC.ActionFilters
{
    public class TransationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            var session = IoC.Container.GetInstance<ISession>();
            session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            var session = IoC.Container.GetInstance<ISession>();

            using (session.Transaction)
            {
                if (session.Transaction.IsActive && filterContext.Exception == null)
                {
                    session.Transaction.Commit();
                }
                else if (session.Transaction.IsActive && filterContext.Exception != null)
                {
                    session.Transaction.Rollback();
                }
            }
        }
    }
}