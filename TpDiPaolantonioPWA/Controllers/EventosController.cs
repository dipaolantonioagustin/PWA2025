using Microsoft.AspNetCore.Mvc;

namespace TpDiPaolantonioPWA.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
