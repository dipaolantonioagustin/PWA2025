using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TpDiPaolantonioPWA.Models;
using TpDiPaolantonioPWA.DAL;

namespace TpDiPaolantonioPWA.Controllers
{
    public class MuestraPermanenteController : BaseController
    {
        private readonly DbmuseoMalbaContext dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MuestraPermanenteController(DbmuseoMalbaContext context)
        {
            dbContext = context;           
        
        }

        public IActionResult Index()
        {   
            List<Obra> listaObras = dbContext.Obras.Include(x => x.IdAutorNavigation).ToList();

            return View("Index", listaObras);
        }



        public string UpLoadFile(_ObraVM obra)
        {
            string nombreArchivo = null;


            if (obra.imgObra != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img", "ColeccionPermanente");
                nombreArchivo = Guid.NewGuid().ToString() + "-" + obra.imgObra.FileName;
                string rutaArchivo = Path.Combine(uploadDir, nombreArchivo);

                using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    obra.imgObra.CopyTo(fileStream);
                }


            }


            return nombreArchivo;
        }
    }
}
