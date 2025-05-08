using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            Evento evento = new Evento();
            List<Evento> listadoEventos = evento.ListarEventos();

            List<Ticket> ticketList = new List<Ticket>();

            ticketList.Add(new Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            ticketList.Add(new Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            ticketList.Add(new Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });

            return View(ticketList);
        }


        [HttpPost]
        public IActionResult ActualizarCalculo()
        {





        }
    }
}
