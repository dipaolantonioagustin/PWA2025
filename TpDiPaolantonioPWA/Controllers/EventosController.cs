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


        [HttpPost]
        public IActionResult Filtrar(Evento eventoBuscado, int? mes, int? anio)
        {
            Evento evento = new Evento();
            List<Evento> listadoEventos = evento.ListarEventos();

            if (!string.IsNullOrEmpty(eventoBuscado.name))

            { listadoEventos = listadoEventos.Where(e => e.name.Contains(eventoBuscado.name, StringComparison.OrdinalIgnoreCase)).ToList(); }

            if (!string.IsNullOrEmpty(eventoBuscado.tipo))

            { listadoEventos = listadoEventos.Where(e => e.tipo == eventoBuscado.tipo).ToList(); }

            if (!string.IsNullOrEmpty(eventoBuscado.foro))

            { listadoEventos = listadoEventos.Where(e => e.foro == eventoBuscado.foro).ToList(); }


            if(mes.HasValue && anio.HasValue)
            
            {   
                DateTime fechaBusquedaInicio = new DateTime(anio.Value, mes.Value, 1);
                DateTime fechaBusquedaFin = fechaBusquedaInicio.AddMonths(1).AddDays(-1);

                listadoEventos = listadoEventos.Where(e => e.fechaInicio <= fechaBusquedaFin && e.fechaFin >= fechaBusquedaInicio).ToList();
                
            }

            return View("Index",listadoEventos);


        }
    }
}
