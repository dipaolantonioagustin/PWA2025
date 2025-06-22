using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using TpDiPaolantonioPWA.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using TpDiPaolantonioPWA.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TpDiPaolantonioPWA.Controllers
{
    public class EventosController : Controller
    {
       private readonly DbmuseoMalbaContext _DbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
       public EventosController(DbmuseoMalbaContext _context, IWebHostEnvironment _webHost)
       {
          _DbContext = _context;
          _webHostEnvironment = _webHost;
       }

        [HttpPost]
        public IActionResult AgregarEvento(_EventoVM e)
        {

            if (e != null)
            {
                string NombreArchivo = UpLoadFile(e);

                Evento evento = new Evento()
                {
                    NombreEvento = e.oEvento.NombreEvento,
                    FechaInicio = e.oEvento.FechaInicio,
                    FechaFin = e.oEvento.FechaFin,
                    Tipo = e.oEvento.Tipo,
                    Sala = e.oEvento.Sala,
                    AutorId = e.oEvento.AutorId,
                    Descripcion = e.oEvento.Descripcion,
                    DescripcionDetalle = e.oEvento.DescripcionDetalle,
                    Portada = NombreArchivo,
                    TipoId = e.oEvento.TipoId,
                    SalaId = e.oEvento.SalaId,
                    Valor = e.oEvento.Valor,

                };

                _DbContext.Eventos.Add(evento);
                _DbContext.SaveChanges();

                TempData["Mensaje"] = "Se Agrego el Evento Correctamente";
                TempData["verificador"] = "true";
            }
            else
            {
                TempData["Mensaje"] = "No Se Pudo Agregar el Evento Correctamente";
                TempData["verificador"] = "false";

            }

            List<Evento> lista = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            return View("EventosABM", lista);


        }

        public IActionResult EventosAlta()
        {
            _EventoVM e = new _EventoVM() //Aca solamente cargo el objeto como la conversion a selectListItem para que en la vista carguen por el tagHelper del Select
            {
                Autor = _DbContext.Autors
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Nombre
                    
                    }).ToList(),
               
                Tipo = _DbContext.TipoEventos
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Tipo

                    }).ToList(),
                Sala = _DbContext.Salas
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.NombreSala

                    }).ToList(),

            };

            return View(e);
        }

        public string UpLoadFile(_EventoVM evento)
        {
            string nombreArchivo = null;
            

            if (evento.fotoEvento != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img", "Eventos");
                nombreArchivo = Guid.NewGuid().ToString() + "-" + evento.fotoEvento.FileName;
                string rutaArchivo = Path.Combine(uploadDir, nombreArchivo);

                using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    evento.fotoEvento.CopyTo(fileStream);
                }

               
            }

           
            return nombreArchivo;
        }

       
        public IActionResult Detalle(int id)
        {
            Evento e = new Evento();
            List<Evento> list = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            e = list.Where(x => x.Id == id).FirstOrDefault();

            return View("Detalle", e);
        }
        public IActionResult EventosABM()
        {

            Evento E = new Evento();
            IEnumerable<Evento> listaEventos = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            return View(listaEventos);
        }


        public IActionResult Index()
        {
            
            _Evento_Tipos listadoGeneral = new _Evento_Tipos();

            listadoGeneral._e = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();
            listadoGeneral._t = _DbContext.TipoEventos.ToList();

            return View(listadoGeneral);
        }


        [HttpPost]
        public IActionResult Filtrar(Evento eventoBuscado, int? mes, int? anio, bool? foro)
        {
            Evento evento = new Evento();
            List<Evento> listadoEventos = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList(); 

            if (!string.IsNullOrEmpty(eventoBuscado.NombreEvento))

            { listadoEventos = listadoEventos.Where(e => e.NombreEvento.Contains(eventoBuscado.NombreEvento, StringComparison.OrdinalIgnoreCase)).ToList(); }

            if (!string.IsNullOrEmpty(eventoBuscado.Autor.Apellido))

            { listadoEventos = listadoEventos.Where(e => e.Autor.Apellido.Contains(eventoBuscado.Autor.Apellido, StringComparison.OrdinalIgnoreCase)).ToList(); }

            if (eventoBuscado.Tipo.Tipo != null)

            { listadoEventos = listadoEventos.Where(e => e.Tipo.Tipo == eventoBuscado.Tipo.Tipo).ToList(); }

            if (foro != null)

            { 
                               
                if(foro == true)
                {
                    listadoEventos = listadoEventos.Where(e => e.Autor.Nacionalidad.Nombre == "argentino").ToList();
                }
                else
                {
                    listadoEventos = listadoEventos.Where(e => e.Autor.Nacionalidad.Nombre != "argentino").ToList();
                }
                
                      
            
            }


            if (mes.HasValue && anio.HasValue)

            {
                DateTime fechaBusquedaInicio = new DateTime(anio.Value, mes.Value, 1);
                DateTime fechaBusquedaFin = fechaBusquedaInicio.AddMonths(1).AddDays(-1);

                listadoEventos = listadoEventos.Where(e => e.FechaInicio <= fechaBusquedaFin && e.FechaFin >= fechaBusquedaInicio).ToList();

            }

            _Evento_Tipos listaEnvio = new _Evento_Tipos();
            listaEnvio._e = listadoEventos;
            listaEnvio._t = _DbContext.TipoEventos.ToList();

            return View("Index", listaEnvio);


        }


        [HttpGet]

        public IActionResult modificar(int id_e)
        {
            List<Evento> listadoGeneral = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            

            _EventoVM e = new _EventoVM()
            {
                Autor = _DbContext.Autors
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Nombre

                    }).ToList(),

                Tipo = _DbContext.TipoEventos
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Tipo

                    }).ToList(),
                Sala = _DbContext.Salas
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.NombreSala

                    }).ToList(),

            };


            e.oEvento = listadoGeneral.FirstOrDefault(x => x.Id == id_e);

            return View("EventosModificar", e);
        }

        [HttpPost]
        public IActionResult modificarEvento(_EventoVM e) 
        {
            List<Evento> listaEventosAnterior = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                 .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            Evento EventoModificar = listaEventosAnterior.FirstOrDefault(x => x.Id == e.oEvento.Id);


           // EventoModificar.Id = e.oEvento.Id;
            EventoModificar.NombreEvento = e.oEvento.NombreEvento;
            EventoModificar.FechaInicio = e.oEvento.FechaInicio;
            EventoModificar.FechaFin = e.oEvento.FechaFin;
            //EventoModificar.Tipo = e.oEvento.Tipo;
            //EventoModificar.Sala = e.oEvento.Sala;
            EventoModificar.AutorId = e.oEvento.AutorId;
            EventoModificar.Descripcion = e.oEvento.Descripcion;
            EventoModificar.DescripcionDetalle = e.oEvento.DescripcionDetalle;

            EventoModificar.TipoId = e.oEvento.TipoId;
            EventoModificar.SalaId = e.oEvento.SalaId;
            EventoModificar.Valor = e.oEvento.Valor;


            if (e.fotoEvento != null)
            {

                string NombreArchivo = UpLoadFile(e);
                EventoModificar.Portada = NombreArchivo;

            }
            else
            {
                EventoModificar.Portada = e.oEvento.Portada;

            }
            _DbContext.Eventos.Update(EventoModificar);
            _DbContext.SaveChanges();

            List<Evento> listaEventos = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            _Evento_Tipos listaEnvio = new _Evento_Tipos();
            listaEnvio._e = listaEventos;
            listaEnvio._t = _DbContext.TipoEventos.ToList();

            return View("Index", listaEnvio);


            
        
        }

        [HttpPost]
        public IActionResult EliminarEvento(_EventoVM e)
        {
           

            Evento evento = new Evento()
            {
                Id = e.oEvento.Id,
                NombreEvento = e.oEvento.NombreEvento,
                FechaInicio = e.oEvento.FechaInicio,
                FechaFin = e.oEvento.FechaFin,
                Tipo = e.oEvento.Tipo,
                Sala = e.oEvento.Sala,
                AutorId = e.oEvento.AutorId,
                Descripcion = e.oEvento.Descripcion,
                DescripcionDetalle = e.oEvento.DescripcionDetalle,
                //Portada = NombreArchivo,
                TipoId = e.oEvento.TipoId,
                SalaId = e.oEvento.SalaId,
                Valor = e.oEvento.Valor,

            };
            _DbContext.Eventos.Remove(evento);
            _DbContext.SaveChanges();

            List<Evento> listaEventos = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();

            _Evento_Tipos listaEnvio = new _Evento_Tipos();
            listaEnvio._e = listaEventos;
            listaEnvio._t = _DbContext.TipoEventos.ToList();

            return View("Index", listaEnvio);




        }

        public IActionResult Eliminar(int id_e)
        {
            List<Evento> listadoGeneral = _DbContext.Eventos.Include(p => p.Autor).ThenInclude(a => a.Nacionalidad)
                .Include(p => p.Sala).Include(p => p.Tipo).ToList();



            _EventoVM e = new _EventoVM()
            {
                Autor = _DbContext.Autors
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Nombre

                    }).ToList(),

                Tipo = _DbContext.TipoEventos
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Tipo

                    }).ToList(),
                Sala = _DbContext.Salas
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.NombreSala

                    }).ToList(),

            };


            e.oEvento = listadoGeneral.FirstOrDefault(x => x.Id == id_e);

            return View("EventosEliminar", e);
        }


    }
}
