using Microsoft.AspNetCore.Mvc;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index(int info)
        {
            _Info i = new _Info();

            List<_Info> li = i.listadoInfo();

            i= li.Where(x => x.id == info).FirstOrDefault();


            return View(i);
        }
    }
}
