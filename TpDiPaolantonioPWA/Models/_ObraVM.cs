using Microsoft.AspNetCore.Mvc.Rendering;

namespace TpDiPaolantonioPWA.Models
{
    public class _ObraVM
    {

        public TpDiPaolantonioPWA.DAL.Obra oObra { get; set; }

        public IFormFile imgObra { get; set; }

        public List<SelectListItem> Autor { get; set; }


    }
}
