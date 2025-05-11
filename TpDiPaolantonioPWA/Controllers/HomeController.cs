using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpDiPaolantonioPWA.Models;

namespace TpDiPaolantonioPWA.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        

       
    }
}
