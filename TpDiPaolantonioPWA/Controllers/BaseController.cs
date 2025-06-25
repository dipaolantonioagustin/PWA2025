using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TpDiPaolantonioPWA.DAL;
using TpDiPaolantonioPWA.Helpers;

namespace TpDiPaolantonioPWA.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var lista = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session,"carrito");
            ViewBag.Contador = lista?.Count ?? 0;

            base.OnActionExecuting(context);
        }
    }
}
