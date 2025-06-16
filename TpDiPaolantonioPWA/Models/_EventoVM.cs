using Microsoft.AspNetCore.Mvc.Rendering;

namespace TpDiPaolantonioPWA.Models
{
    public class _EventoVM
    {
        public TpDiPaolantonioPWA.DAL.Evento oEvento { get; set; }

        public IFormFile fotoEvento { get; set; }

        public List<SelectListItem> Autor { get; set; }

        public List<SelectListItem> Tipo {get; set;}

        public List<SelectListItem> Sala { get; set; }

   
    
    }


}
