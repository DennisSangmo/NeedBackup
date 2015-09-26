using System.Web.Mvc;
using NeedBackup.Web.MVC.ActionFilters;

namespace NeedBackup.Web.Controllers
{
    [Transation]
    public abstract class BaseController : Controller
    {

    }
}