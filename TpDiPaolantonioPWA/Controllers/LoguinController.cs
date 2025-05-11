using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class LoguinController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Logueo(Usuario usu)
        {
            Usuario usuario = new Usuario();
            List<Usuario> lista = usuario.ListaUsuarios();

            var Usuario = lista.Where(x => x.email == usu.email).FirstOrDefault();

            if(Usuario != null)
            {
                if (usu.clave == "1234") { 
                    TempData["AlertMensaje"] = "Ha podido Igresar Correctamente";
                    TempData["Key"] = "true";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertMensaje"] = "No ha podido Igresar Correctamente";
                    TempData["Key"] = "false";
                    return RedirectToAction("Index");
                }
            }
           

            TempData["AlertMensaje"] = "Algo Salió Mal";
            TempData["Key"] = "false";

            return RedirectToAction("Index");
        }
    }
}
