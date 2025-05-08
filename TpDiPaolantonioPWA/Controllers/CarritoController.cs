using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
            Carrito carrito = new Carrito();
            carrito.tickets = ticketList;

            return View(carrito);
        }

        [HttpPost]
        public IActionResult CalcularDescuento(string carritoJson, bool socio, float importe)
        {

            Carrito carrito = JsonSerializer.Deserialize<Carrito>(carritoJson);
            carrito.usuario.socio = socio;
            carrito.CalcularDescuento();

            return View("DetalleCompra", carrito);

        }


        [HttpPost]
        public IActionResult CalcularGastosOperativos(string carritoJson)
        {

            Carrito carrito = JsonSerializer.Deserialize<Carrito>(carritoJson);
            
            carrito.CalcularGastosOperativos();

            return View("DetalleCompra", carrito);

        }

        public IActionResult DetalleCompra()
        {

            Evento evento = new Evento();
            List<Evento> listadoEventos = evento.ListarEventos();

            List<Ticket> ticketList = new List<Ticket>();

            ticketList.Add(new Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            ticketList.Add(new Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            ticketList.Add(new Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });
            Carrito carrito = new Carrito();
            carrito.tickets = ticketList;
            carrito.CalcularGastosOperativos();
            return View("DetalleCompra", carrito);
        }

        // [HttpPost]
        // public IActionResult ActualizarCalculo()
        //{


        //  return View();


        //        }
    }
}
