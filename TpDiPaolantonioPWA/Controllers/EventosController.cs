using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            Evento evento = new Evento();
            List<Evento> listadoEventos = evento.ListarEventos();
            return View(listadoEventos);
        }
    }
}
