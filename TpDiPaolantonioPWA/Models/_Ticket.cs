namespace TpDiPaolantonioPWA.Models
{
    public class _Ticket
    {
        public int Id { get; set; }
        public _Eventos evento_ticket {  get; set; }
                 
        public int cantidad {  get; set; }

        public DateTime fecha { get; set; } 


        public float TotalEntradas()
        {
            return this.cantidad * this.evento_ticket.valor;
        }


        public _Ticket()
        {
            evento_ticket = new _Eventos();

        }


    }
}
