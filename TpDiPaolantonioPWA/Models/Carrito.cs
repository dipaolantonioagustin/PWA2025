namespace TpDiPaolantonioPWA.Models
{
    public class Carrito
    {


        public List<Ticket> tickets { get; set; }

        public float impuestos { get; set; }
        public float gastos_aderidos { get; set; }
        public float descuentos { get; set; }

        public float total {  get; set; }   

        public void agregarTicket(Evento eventos, int cantidades)
        {
            Ticket verificador = tickets.FirstOrDefault(x => x.evento_ticket.id == eventos.id);


            if (verificador != null)
            {

                verificador.cantidad += cantidades;

            }

            else
            {
                tickets.Add(new Ticket
                {
                    evento_ticket = eventos,
                    cantidad = cantidades


                });

            }
        }

        public void sacarTicket(Evento eventos, int cantidades)
        {

            Ticket verificador = tickets.FirstOrDefault(x => x.evento_ticket.id == eventos.id);


            if (verificador != null)
            {
                 
                if(verificador.cantidad-cantidades == 0)
                {
                    tickets.Remove(verificador);
                }
                else
                {
                    verificador.cantidad -= cantidades;

                }
               

            }

            else
            {
                //alerta de que no hay 

            }

        }


        public float CalculadorTotal()
        {
            float total = 0;
            //float subTotal = 0;

            foreach (Ticket T in this.tickets)
            {
                int cant = T.cantidad;
                float valor = T.evento_ticket.valor;

                float subTotal = cant * valor;

                if(this.descuentos != 0)
                {
                    subTotal = subTotal - subTotal * (this.descuentos / 100);
                }


                if (this.impuestos != 0)
                {
                    subTotal = subTotal + subTotal * (this.impuestos / 100);
                }


                if (this.gastos_aderidos != 0)
                {
                    subTotal = this.gastos_aderidos;
                }

                total += subTotal;

            }

           

            return total;
        }
    }
}