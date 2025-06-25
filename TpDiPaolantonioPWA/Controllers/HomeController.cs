using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpDiPaolantonioPWA.Models;
using TpDiPaolantonioPWA.DAL;

namespace TpDiPaolantonioPWA.Controllers
{
    public class HomeController : BaseController
    {
        private readonly DbmuseoMalbaContext _DbContext;
        public HomeController(DbmuseoMalbaContext _context)
        {
            
            
            
            _DbContext = _context;

        }


        public IActionResult Index()
        {

            Usuario usu = new Usuario()
            {

                Id = 1,
                nombre = "Agustin A Di Paolantonio",
                Email = "dipaolantonias@gmail.com",

            };

            Helpers.sesionHelpers.SetObjectAsJson(HttpContext.Session, "Usuario", usu);

            return View();


        }

        

       
    }
}
