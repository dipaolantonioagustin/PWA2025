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

        public string pais {  get; set; }   

        public string portada {  get; set; }    


        public List<Evento> ListarEventos()
        {
            List<Evento> listaEventos = new List<Evento>();


            Evento e1 = new Evento();
            e1.id = 1;
            e1.name = "Kuitca y Moura en Dialogos";
            e1.autor = "Kuitca";
            e1.sala = "Tercer Ojo";
            e1.description = "Malba presenta una conversación pública entre Guillermo Kuitca y Rodrigo Moura, flamante director artístico de la institución.";
            e1.pais = "Argentina";
            e1.fechaInicio = new DateTime(2025, 5, 5);
            e1.fechaFin = new DateTime(2025, 7, 10);
            e1.portada = "/img/Eventos/Kuitca.png";


            listaEventos.Add(e1);


            Evento e2 = new Evento();
            e2.id = 1;
            e2.name = "Cine Portugues";
            e2.autor = "Directores Portugal";
            e2.sala = "Frida";
            e2.description = "La 12ª Semana de Cine Portugués reafirma su misión de exhibir en la Ciudad de Buenos Aires una muestra del mejor cine portugués contemporáneo.";
            e2.pais = "Portugal";
            e2.fechaInicio = new DateTime(2025, 6, 2);
            e2.fechaFin = new DateTime(2025, 10, 10);
            e2.portada = "/img/Eventos/CinePortugues.png";


            listaEventos.Add(e2);






            return listaEventos;
        }

    }
}
