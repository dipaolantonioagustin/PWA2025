using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class CarritoController : Controller
    {
        
        public IActionResult Index()
        {
            _Eventos evento = new _Eventos();
            List<_Eventos> listadoEventos = evento.ListarEventos();

            List<_Ticket> ticketList = new List<_Ticket>();

            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });
            _Carrito carrito = new _Carrito();
            carrito.tickets = ticketList;

            return View("Index",carrito);
        }

        [HttpPost]
        public IActionResult CalcularDescuento(string carritoJson, bool socio, float importe)
        {

            _Carrito carrito = JsonSerializer.Deserialize<_Carrito>(carritoJson);
            carrito.usuario.socio = socio;
            carrito.CalcularDescuento();

            ViewBag.socio = socio;

            return View("DetalleCompra", carrito);

        }


        [HttpPost]
        public IActionResult CalcularGastosOperativos(string carritoJson)
        {

            _Carrito carrito = JsonSerializer.Deserialize<_Carrito>(carritoJson);
            
            carrito.CalcularGastosOperativos();

            return View("DetalleCompra", carrito);

        }

        public IActionResult DetalleCompra()
        {

            _Eventos evento = new _Eventos();
            List<_Eventos> listadoEventos = evento.ListarEventos();

            List<_Ticket> ticketList = new List<_Ticket>();

            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });
            _Carrito carrito = new _Carrito();
            carrito.tickets = ticketList;
            carrito.CalcularGastosOperativos();
            return View("DetalleCompra", carrito);
        }


        public IActionResult ConfirmarCompra(_Carrito c) {

            _Eventos evento = new _Eventos();
            List<_Eventos> listadoEventos = evento.ListarEventos();

            List<_Ticket> ticketList = new List<_Ticket>();

            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            ticketList.Add(new _Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });
            _Carrito carrito = new _Carrito();
            carrito.tickets = ticketList;
            carrito.CalcularGastosOperativos();

            return View("ConfirmarCompra", carrito);
        }

        public IActionResult FinalizaCompra(string medioPago, string tarjetaEmpresa, int numeroTarjeta, int clave)
        {
            if(clave == 4455)
            {
                TempData["Mensaje"] = "Felicitaciones !!! Compra Aprobada";
                TempData["Estado"] = "Exitosa";
            }
            else
            {
                TempData["Mensaje"] = "Algo salio Mal, Compra Denegada";
                TempData["Estado"] = "Denegada";

            }


            return RedirectToAction("ResultadoCompra");


        }


        public IActionResult ResultadoCompra() { return View(); }



    }
}
