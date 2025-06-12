using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class MuestraPermanenteController : Controller
    {
        public IActionResult Index()
        {   _Obra obra = new _Obra();
            List<_Obra> listaObras = obra.ListarObras();

            return View("Index", listaObras);
        }




    }
}
