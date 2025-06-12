using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using TpDiPaolantonioPWA.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using TpDiPaolantonioPWA.DAL;
using Microsoft.EntityFrameworkCore;


namespace TpDiPaolantonioPWA.Controllers
{
    public class EventosController : Controller
    {
       private readonly DbmuseoMalbaContext _DbContext;
       public EventosController(DbmuseoMalbaContext _context)
       {
          _DbContext = _context;
       }


        //public IActionResult AgregarEvento(Evento e)
        //{
        //    Evento evento = new Evento();
        //    List<Evento> eventos = evento.ListarEventos();
        //    eventos.Add(e);
            
        //    if (e != null)
        //    {
        //        TempData["Mensaje"] = "Se Agrego el Evento Correctamente";
        //        TempData["verificador"] = "true";
        //    }
        //    else 
        //    {
        //        TempData["Mensaje"] = "No Se Pudo Agregar el Evento Correctamente";
        //        TempData["verificador"] = "false";

        //    }
            

        //    return View("EventosABM", eventos);

            
        //}
        //public IActionResult EventosAlta()
        //{
        //    return View();
        //}

        // [HttpPost]
        //public IActionResult AgregarTickets(int cantidad, int e)
        //{
        //    Evento evento = new Evento();
        //    List<Evento> listaEventos = evento.ListarEventos();

        //    evento = listaEventos.Where(x => x.id == e).FirstOrDefault();


        //    if (cantidad >= 1)
        //    {
        //        TempData["Mensaje"] = "Se han Agregado los Tickets a su Carrito";
        //        TempData["Key"] = "true";
        //    }
        //    else if (cantidad < 1)
        //    {
        //        TempData["Mensaje"] = "El Número de Tickets no Puede ser Menor a 1";
        //        TempData["Key"] = "false";
        //    }
          

        //    return View("Detalle", evento);
        //}
        //public IActionResult Detalle(int id)
        //{
        //    Evento e = new Evento();
        //    List<Evento> list = e.ListarEventos();
            
        //    e= list.Where(x => x.id == id).FirstOrDefault();

        //    return View("Detalle",e);
        //}
        //public IActionResult EventosABM()
        //{

        //    Evento E = new Evento();
        //    IEnumerable<Evento> listaEventos = E.ListarEventos();

        //    return View(listaEventos);
        //}


        public IActionResult Index()
        {
            // Evento evento = new Evento();
            List<Evento> listadoEventos = _DbContext.Eventos.Include(p => p.Autor)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();
           
            return View(listadoEventos);
        }


        //[HttpPost]
        //public IActionResult Filtrar(Evento eventoBuscado, int? mes, int? anio)
        //{
        //    Evento evento = new Evento();
        //    List<Evento> listadoEventos = evento.ListarEventos();

        //    if (!string.IsNullOrEmpty(eventoBuscado.name))

        //    { listadoEventos = listadoEventos.Where(e => e.name.Contains(eventoBuscado.name, StringComparison.OrdinalIgnoreCase)).ToList(); }

        //    if (!string.IsNullOrEmpty(eventoBuscado.autor))

        //    { listadoEventos = listadoEventos.Where(e => e.autor.Contains(eventoBuscado.autor, StringComparison.OrdinalIgnoreCase)).ToList(); }

        //    if (!string.IsNullOrEmpty(eventoBuscado.tipo))

        //    { listadoEventos = listadoEventos.Where(e => e.tipo == eventoBuscado.tipo).ToList(); }

        //    if (!string.IsNullOrEmpty(eventoBuscado.foro))

        //    { listadoEventos = listadoEventos.Where(e => e.foro == eventoBuscado.foro).ToList(); }


        //    if(mes.HasValue && anio.HasValue)
            
        //    {   
        //        DateTime fechaBusquedaInicio = new DateTime(anio.Value, mes.Value, 1);
        //        DateTime fechaBusquedaFin = fechaBusquedaInicio.AddMonths(1).AddDays(-1);

        //        listadoEventos = listadoEventos.Where(e => e.fechaInicio <= fechaBusquedaFin && e.fechaFin >= fechaBusquedaInicio).ToList();
                
        //    }

        //    return View("Index",listadoEventos);


        //}
    }
}
