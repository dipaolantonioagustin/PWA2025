using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;
using TpDiPaolantonioPWA.DAL;
using TpDiPaolantonioPWA.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.Controllers
{
    public class TicketsController : BaseController
    {
        private readonly DbmuseoMalbaContext _DbContext;
        public TicketsController(DbmuseoMalbaContext _context)
        {
            _DbContext = _context;
        }
        public IActionResult Index()
        {
            _Eventos evento = new _Eventos();
            List<_Eventos> listadoEventos = evento.ListarEventos();

            return View(listadoEventos);
        }

        private float CalcularValorTotal(Ticket t)
        {
            List<Evento> e = _DbContext.Eventos.ToList();
            if (e != null)
            {
                return (float)(t.CantEntradas * t.IdEventoNavigation.Valor);
            }
            else { return 0; }
            
        
        }

        public IActionResult TicketsUsuario(int pg=1) 
        {
            _TicketsUsuario t = new _TicketsUsuario() {

                
                usuario = Helpers.sesionHelpers.GetObjectFromJson<Usuario>(HttpContext.Session, "Usuario")


            };

            List<Ticket> listadoTickets = _DbContext.Tickets.Include(t => t.IdEventoNavigation).ToList();

            const int TamanioPagina = 5;

            pg = (pg < 1) ? 1: pg;
            
            int tamanioListado = listadoTickets.Count;

            var pager = new Pager(tamanioListado, pg, TamanioPagina);

            int salto = (pg-1)* TamanioPagina;

            var listaFinal = listadoTickets.Skip(salto).Take(pager.PaginaTamanio).ToList();

            ViewBag.Pager = pager;

            t.listadoTickets = listaFinal;

                   
            return View(t);
        
        }


        private void limpiarTicketsSesion() 
        {

            List<Ticket> listadoLimpio = new List<Ticket>();
        
            Helpers.sesionHelpers.SetObjectAsJson(HttpContext.Session,"carrito",listadoLimpio);
        
        
        }
        public IActionResult GuardarTicket()
        {
            List<Ticket> listadoTickets = Helpers.sesionHelpers.GetObjectFromJson<List<Ticket>>(HttpContext.Session, "carrito");
            

            if (listadoTickets != null)
            {
               
                foreach (Ticket t in listadoTickets) 
                {

                    Ticket ticket = new Ticket()
                    {
                        IdEvento = t.IdEvento,
                        CantEntradas = t.CantEntradas,
                        ValorTotal = CalcularValorTotal(t)

                    };
                    
                    _DbContext.Tickets.Add(ticket);

                }
                
                
                _DbContext.SaveChanges();

                TempData["Mensaje"] = "Se Agregaron los Tickets Correctamente";
                TempData["validador"] = true;

                limpiarTicketsSesion();
            }
            else
            {
                TempData["Mensaje"] = "No Se Pudo Agregar el Ticket Correctamente";
                TempData["validador"] = false;

            }

            List<Ticket> lista = _DbContext.Tickets.Include(p => p.IdEventoNavigation).ToList();

           

            return RedirectToAction("ResultadoCompra","Carrito");
        
        }

    }


    
}
