using System;
using System.Web.Mvc;
using System.Web.Routing;
using NeedBackup.Core.IoC;

namespace NeedBackup.Web.MVC
{
    public class NeedBackupControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            return (IController) IoC.Container.GetInstance(controllerType);
        }
    }
}