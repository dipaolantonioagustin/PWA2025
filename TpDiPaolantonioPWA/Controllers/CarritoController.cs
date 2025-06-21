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
            listadoCompra = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "carrito");
            evento = _DbContext.Eventos.Include(a => a.Autor).ThenInclude(a=>a.Nacionalidad).Include(a=> a.Sala).Include(a=>a.Tipo).ToList();

            _Tickets_Eventos listado = new _Tickets_Eventos();
            listado.listaTickets = listadoCompra;
            listado.listaEvento = evento;
                                    
            return View("Index", listado);
        }
        
        
        [HttpPost]
        public IActionResult EliminarTicket(int id)
        {
            evento = _DbContext.Eventos.Include(a => a.Autor).ThenInclude(a => a.Nacionalidad).Include(a => a.Sala).Include(a => a.Tipo).ToList();
            var listadoCarrito = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "carrito");
            
            _Tickets_Eventos listado = new _Tickets_Eventos();
            
            listado.listaEvento = evento;

        

            Ticket ticket = listadoCarrito.FirstOrDefault(x => x.TempId == id);

           

            if (ticket == null)
            {
                listado.listaTickets = listadoCarrito;
                return View("Index", listado);

            }
            else 
            {

                listadoCarrito.Remove(ticket);

                listado.listaTickets = listadoCarrito;

                Helpers.sesionHelpers.SetObjectAsJson(HttpContext.Session, "carrito", listadoCarrito);
          

                return View("Index", listado);

            }


           
        
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
                    TempId = 1,
                    IdEvento = e.Id,
                    CantEntradas = cant,
                    IdEventoNavigation = e,
                    ValorTotal = e.Valor * cant,


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
                        TempId= listadoCarrito.Count + 1,
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
                     
            List<Evento> listadoEventos = _DbContext.Eventos.ToList();
            List<Ticket> ticketList = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session,"carrito");
                       
            _Carrito carrito = new _Carrito();
            carrito.tickets = ticketList;
            carrito.CalcularGastosOperativos();
            return View("DetalleCompra", carrito);

        }


        public IActionResult ConfirmarCompra(float valor)
        {

            return View("ConfirmarCompra", valor);


        }

        public IActionResult FinalizaCompra(string medioPago, string tarjetaEmpresa, int numeroTarjeta, int clave)
        {
            if(clave == 4455)
            {


                return RedirectToAction("GuardarTicket", "Tickets");



                //TempData["Mensaje"] = "Felicitaciones !!! Compra Aprobada";
                //TempData["Estado"] = "Exitosa";
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
