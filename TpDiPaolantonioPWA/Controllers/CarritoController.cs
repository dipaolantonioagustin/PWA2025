using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TpDiPaolantonioPWA.Models;
using TpDiPaolantonioPWA.DAL;
using TpDiPaolantonioPWA.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Options;

namespace TpDiPaolantonioPWA.Controllers
{
    public class CarritoController : Controller
    {
        public List<Ticket> listadoCompra = new List<Ticket>();
        public List<Evento> evento = new List<Evento>();

        private readonly DbmuseoMalbaContext _DbContext;
        public CarritoController(DbmuseoMalbaContext _context)
        {
            _DbContext = _context;
        }
        public IActionResult Index()
        {
            listadoCompra = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "tk");
            evento = _DbContext.Eventos.Include(a => a.Autor).ThenInclude(a=>a.Nacionalidad).Include(a=> a.Sala).Include(a=>a.Tipo).ToList();

            _Tickets_Eventos listado = new _Tickets_Eventos();
            listado.listaTickets = listadoCompra;
            listado.listaEvento = evento;


            //foreach (Ticket ticket in listadoCompra) {

            //    ticket.IdEventoNavigation = evento.FirstOrDefault<Evento>(ticket.IdEvento);  
            
            
            //}

            //_Eventos evento = new _Eventos();
            //List<_Eventos> listadoEventos = evento.ListarEventos();

            //List<_Ticket> ticketList = new List<_Ticket>();

            //ticketList.Add(new _Ticket { evento_ticket = listadoEventos[0], cantidad = 2, Id = 1 });
            //ticketList.Add(new _Ticket { evento_ticket = listadoEventos[3], cantidad = 4, Id = 2 });
            //ticketList.Add(new _Ticket { evento_ticket = listadoEventos[1], cantidad = 1, Id = 3 });
            //_Carrito carrito = new _Carrito();
            //carrito.tickets = ticketList;

            return View("Index", listado);
        }




        private int Exist(List<Ticket> ticketsListado, int id)
        {
            for (int i = 0; i < ticketsListado.Count; i++) 
            {
                if (ticketsListado[i].Id.Equals(id))
                {
                    return i;
                }
            
            
            }

            return -1;
        }


        [HttpPost]
        public IActionResult AgregarTicket(int id, int cant)
        {

            List<Evento> eventos = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                 .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            Evento e = eventos.FirstOrDefault(x => x.Id == id);

            var listadoCarrito = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "carrito");

            if (listadoCarrito == null) 
            {
                List<Ticket> carrito = new List<Ticket>();
                carrito.Add(new Ticket()
                {
                    IdEvento=e.Id,
                    CantEntradas=cant,
                    IdEventoNavigation = e,
                    ValorTotal = e.Valor*cant,
                   

                });

                Helpers.sesionHelpers.SetObjectAsJson(HttpContext.Session, "carrito", carrito);

            }
            else
            {
              
                int index = Exist(listadoCarrito, e.Id);
               
                if(index == -1)
                {
                    listadoCarrito.Add(new Ticket()
                    {
                        IdEvento = e.Id,
                        CantEntradas = cant,
                        IdEventoNavigation = e,
                        ValorTotal = e.Valor * cant,


                    });
                }
                else
                {
                    listadoCarrito[index].CantEntradas = listadoCarrito[index].CantEntradas + cant;

                }
                
                Helpers.sesionHelpers.SetObjectAsJson(HttpContext.Session,"carrito",listadoCarrito);

            }

            return RedirectToAction("Detalle","Eventos", e);
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
