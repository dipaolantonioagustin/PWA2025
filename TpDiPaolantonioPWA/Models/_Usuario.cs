using System.ComponentModel.DataAnnotations.Schema;

namespace TpDiPaolantonioPWA.Models
{
    public class _Usuario
    {
        public string nombre { get; set; }
        public string apellido {  get; set; }
        public int dni {  get; set; }
        public bool socio {  get; set; }

        public string email {  get; set; }
        public string clave {  get; set; }


        public List<_Usuario> ListaUsuarios()
        {
           
            List<_Usuario> listaUsuario =  new List<_Usuario>();

            listaUsuario.Add(new _Usuario { nombre = "Pedrito", apellido = "Montes", dni = 11111111, socio = true, email = "pedrito@gmail.com", clave = "1234" });
            listaUsuario.Add(new _Usuario { nombre = "Raquelita", apellido = "Cortez", dni = 11111112, socio = false, email = "raquelita@gmail.com", clave = "1234" });
            
            return listaUsuario;
        }
        
    }
}
