using Microsoft.AspNetCore.Mvc;

namespace TpDiPaolantonioPWA.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RecibirMensaje(string mail, string asunto, string mensaje)
        {
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(asunto) && !string.IsNullOrEmpty(mensaje))
            {
                TempData["Mensaje"] = "Hemos recibido tu mensaje, Gracias por escribirnos";
                TempData["verificador"] = "true";

            }

            return RedirectToAction("Index");

        }
    }
}
