using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            Evento evento = new Evento();
            List<Evento> listadoEventos = evento.ListarEventos();

            return View(listadoEventos);
        }



    }
}
