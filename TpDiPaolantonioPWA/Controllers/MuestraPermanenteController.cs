using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class MuestraPermanenteController : Controller
    {
        public IActionResult Index()
        {   Obra obra = new Obra();
            List<Obra> listaObras = obra.ListarObras();

            return View("Index", listaObras);
        }




    }
}
