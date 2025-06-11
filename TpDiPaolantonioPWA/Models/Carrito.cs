namespace TpDiPaolantonioPWA.Models
{
    public class Carrito
    {


        public List<Ticket> tickets { get; set; }

        public Usuario usuario { get; set; } 
        public float impuestos { get; set; }
        public float gastos_aderidos { get; set; }
        public float descuentos { get; set; }

        public float total {  get; set; }

        public float porcentualGastoOperativo{ get; set; }

        public Carrito() { usuario = new Usuario(); porcentualGastoOperativo = (float) 0.025; }

        public void CalcularGastosOperativos()
        {
            this.gastos_aderidos =  this.sumarEntradas() * porcentualGastoOperativo;
        }
       
        
        public void CalcularDescuento()
        {
          
                      
            if (this.usuario.socio == true) {  this.descuentos = this.sumarEntradas() * (float)0.10;}
            else
            {
                this.descuentos = 0;
            }



            
        }
        public void agregarTicket(Eventos eventos, int cantidades)
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

        public void sacarTicket(Eventos eventos, int cantidades)
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
        public float sumarEntradas()
        {
            float sumatoria = 0;

            foreach (var item in tickets)
            {
                sumatoria += item.cantidad * item.evento_ticket.valor;
            }

            return sumatoria;
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

                                
                total += subTotal;

            }

            
            this.CalcularDescuento();

            if (this.descuentos != 0)
            {
                total = total - this.descuentos;
            }

            this.CalcularGastosOperativos();

            if (this.gastos_aderidos != 0)
            {
                total = total +  this.gastos_aderidos;
            }

            return total;
        }
    }
}