using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            Eventos evento = new Eventos();
            List<Eventos> listadoEventos = evento.ListarEventos();

            return View(listadoEventos);
        }



    }
}
