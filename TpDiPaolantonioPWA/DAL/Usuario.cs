namespace TpDiPaolantonioPWA.DAL
{
    public class Usuario
    {

        public int Id { get; set; } 

        public string nombre { get; set; }

        public string Email { get; set;  }

        public string Clave { get; set; }

        public ICollection<Ticket> ListadoTicketUsuario { get; set; }



    }
}
