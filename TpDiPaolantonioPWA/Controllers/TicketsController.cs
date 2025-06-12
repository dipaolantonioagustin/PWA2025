using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            _Eventos evento = new _Eventos();
            List<_Eventos> listadoEventos = evento.ListarEventos();

            return View(listadoEventos);
        }



    }
}
