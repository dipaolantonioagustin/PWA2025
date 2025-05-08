using System.ComponentModel.DataAnnotations.Schema;

namespace TpDiPaolantonioPWA.Models
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string apellido {  get; set; }
        public int dni {  get; set; }
        public bool socio {  get; set; }

        
    }
}
