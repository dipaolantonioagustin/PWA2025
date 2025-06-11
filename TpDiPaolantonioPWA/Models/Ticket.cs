namespace TpDiPaolantonioPWA.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Eventos evento_ticket {  get; set; }
                 
        public int cantidad {  get; set; }

        public DateTime fecha { get; set; } 


        public float TotalEntradas()
        {
            return this.cantidad * this.evento_ticket.valor;
        }


        public Ticket()
        {
            evento_ticket = new Eventos();

        }


    }
}
