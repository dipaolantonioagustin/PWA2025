using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpDiPaolantonioPWA.Models;
using TpDiPaolantonioPWA.DAL;

namespace TpDiPaolantonioPWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbmuseoMalbaContext _DbContext;
        public HomeController(DbmuseoMalbaContext _context)
        {
            _DbContext = _context;
        }


        public IActionResult Index()
        {
            return View();
        }

        

       
    }
}
