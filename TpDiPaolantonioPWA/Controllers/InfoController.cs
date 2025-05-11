using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index(int info)
        {
            Info i = new Info();

            List<Info> li = i.listadoInfo();

            i= li.Where(x => x.id == info).FirstOrDefault();


            return View(i);
        }
    }
}
