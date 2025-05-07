namespace TpDiPaolantonioPWA.Models
{
    public class Evento
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin {  get; set; }
        public string autor { get; set; }

        public string sala {  get; set; }   

        public string foro {  get; set; }   

        public string portada {  get; set; } 
        
        public string tipo { get; set; }


        public List<Evento> ListarEventos()
        {
            List<Evento> listaEventos = new List<Evento>();


            Evento e1 = new Evento();
            e1.id = 1;
            e1.name = "Kuitca y Moura en Dialogos";
            e1.autor = "Kuitca";
            e1.sala = "Tercer Ojo";
            e1.description = "Malba presenta una conversación pública entre Guillermo Kuitca y Rodrigo Moura, flamante director artístico de la institución.";
            e1.foro = "Nacional";
            e1.fechaInicio = new DateTime(2025, 5, 5);
            e1.fechaFin = new DateTime(2025, 7, 10);
            e1.portada = "/img/Eventos/Kuitca.png";
            e1.tipo = "Recital";


            listaEventos.Add(e1);


            Evento e2 = new Evento();
            e2.id = 2;
            e2.name = "Cine Portugues";
            e2.autor = "Directores Portugal";
            e2.sala = "Frida";
            e2.description = "La 12ª Semana de Cine Portugués reafirma su misión de exhibir en la Ciudad de Buenos Aires una muestra del mejor cine portugués contemporáneo.";
            e2.foro = "Internacional";
            e2.fechaInicio = new DateTime(2025, 6, 2);
            e2.fechaFin = new DateTime(2025, 10, 10);
            e2.portada = "/img/Eventos/CinePortugues.png";
            e2.tipo = "Muestra";

            listaEventos.Add(e2);

            Evento e3 = new Evento();
            e3.id = 3;
            e3.name = "Kuitca y Moura en Dialogos";
            e3.autor = "Kuitca";
            e3.sala = "Tercer Ojo";
            e3.description = "Malba presenta una conversación pública entre Guillermo Kuitca y Rodrigo Moura, flamante director artístico de la institución.";
            e3.foro = "Nacional";
            e3.fechaInicio = new DateTime(2025, 5, 5);
            e3.fechaFin = new DateTime(2025, 7, 10);
            e3.portada = "/img/Eventos/Kuitca.png";
            e3.tipo = "Conferencia";

            listaEventos.Add(e3);

            Evento e4 = new Evento();
            e4.id = 3;
            e4.name = "Kuitca y Moura en Dialogos";
            e4.autor = "Kuitca";
            e4.sala = "Tercer Ojo";
            e4.description = "Malba presenta una conversación pública entre Guillermo Kuitca y Rodrigo Moura, flamante director artístico de la institución.";
            e4.foro = "Nacional";
            e4.fechaInicio = new DateTime(2025, 5, 5);
            e4.fechaFin = new DateTime(2025, 7, 10);
            e4.portada = "/img/Eventos/Kuitca.png";
            e4.tipo = "Muestra";

            listaEventos.Add(e4);

            Evento e5 = new Evento();
            e5.id = 3;
            e5.name = "Kuitca y Moura en Dialogos";
            e5.autor = "Kuitca";
            e5.sala = "Tercer Ojo";
            e5.description = "Malba presenta una conversación pública entre Guillermo Kuitca y Rodrigo Moura, flamante director artístico de la institución.";
            e5.foro = "Internacional";
            e5.fechaInicio = new DateTime(2025, 5, 5);
            e5.fechaFin = new DateTime(2025, 7, 10);
            e5.portada = "/img/Eventos/Kuitca.png";
            e5.tipo = "Conferencia";

            listaEventos.Add(e5);



            return listaEventos;
        }

    }
}
