using System.ComponentModel.DataAnnotations.Schema;

namespace TpDiPaolantonioPWA.Models
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string apellido {  get; set; }
        public int dni {  get; set; }
        public bool socio {  get; set; }

        public string email {  get; set; }
        public string clave {  get; set; }


        public List<Usuario> ListaUsuarios()
        {
           
            List<Usuario> listaUsuario =  new List<Usuario>();

            listaUsuario.Add(new Usuario { nombre = "Pedrito", apellido = "Montes", dni = 11111111, socio = true, email = "pedrito@gmail.com", clave = "1234" });
            listaUsuario.Add(new Usuario { nombre = "Raquelita", apellido = "Cortez", dni = 11111112, socio = false, email = "raquelita@gmail.com", clave = "1234" });
            
            return listaUsuario;
        }
        
    }
}
