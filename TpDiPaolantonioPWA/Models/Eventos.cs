namespace TpDiPaolantonioPWA.Models
{
    public class Eventos
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


        public float valor {  get; set; }

        public int capacidad {  get; set; }

        public string DescripcionDetallada {  get; set; }


        public List<Eventos> ListarEventos()
        {
            List<Eventos> listaEventos = new List<Eventos>();


            Eventos e1 = new Eventos();
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
            e1.valor = 12500;
            e1.DescripcionDetallada = "En el año 1981 mudó su taller a la calle Cangallo al 2300 donde trabajó hasta 1993. Allí pintó la serie Nadie olvida nada, que recibió el Premio al Artista Joven del Año de la Asociación Argentina de Críticos de Arte y el Premio del Café Einstein. También dirigió su primer espectáculo teatral junto con Carlos Ianni (1982). Participó en Ex-Presiones'83 en el Centro Cultural Recoleta. En 1984 Realizó su primera exposición en la galería de Julia Lublin, y estrenó su segunda obra teatral en colaboración con Carlos Ianni, El Mar Dulce y pintó la serie del mismo nombre. En 1985 realizó su primera muestra en la Galería Elizabeth Franck, Bélgica, y junto al grupo La nueva imagen, participó en el XVIII Bienal de San Pablo, donde presentó las cuatro obras de la serie Yo, como... y en la Galería del Retiro, con su serie Siete últimas canciones realizó su última muestra individual en la Argentina hasta casi 20 años después.\r\nNadie olvida nada, \"Ese año pasaba de todo en la Argentina y le dije adiós a lo que había hecho antes. Fue un movimiento de mucha introspección e intensidad\". Entonces surgió la serie Nadie olvida nada, germen de lo que vino después y núcleo del que parten sus muestras antológicas.[7]​";





            listaEventos.Add(e1);


            Eventos e2 = new Eventos();
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
            e2.valor = 12500;
            e2.DescripcionDetallada = "En el año 1981 mudó su taller a la calle Cangallo al 2300 donde trabajó hasta 1993. Allí pintó la serie Nadie olvida nada, que recibió el Premio al Artista Joven del Año de la Asociación Argentina de Críticos de Arte y el Premio del Café Einstein. También dirigió su primer espectáculo teatral junto con Carlos Ianni (1982). Participó en Ex-Presiones'83 en el Centro Cultural Recoleta. En 1984 Realizó su primera exposición en la galería de Julia Lublin, y estrenó su segunda obra teatral en colaboración con Carlos Ianni, El Mar Dulce y pintó la serie del mismo nombre. En 1985 realizó su primera muestra en la Galería Elizabeth Franck, Bélgica, y junto al grupo La nueva imagen, participó en el XVIII Bienal de San Pablo, donde presentó las cuatro obras de la serie Yo, como... y en la Galería del Retiro, con su serie Siete últimas canciones realizó su última muestra individual en la Argentina hasta casi 20 años después.\r\nNadie olvida nada, \"Ese año pasaba de todo en la Argentina y le dije adiós a lo que había hecho antes. Fue un movimiento de mucha introspección e intensidad\". Entonces surgió la serie Nadie olvida nada, germen de lo que vino después y núcleo del que parten sus muestras antológicas.[7]​";
            listaEventos.Add(e2);

            Eventos e3 = new Eventos();
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
            e3.valor = 15500;
            e3.DescripcionDetallada = "En el año 1981 mudó su taller a la calle Cangallo al 2300 donde trabajó hasta 1993. Allí pintó la serie Nadie olvida nada, que recibió el Premio al Artista Joven del Año de la Asociación Argentina de Críticos de Arte y el Premio del Café Einstein. También dirigió su primer espectáculo teatral junto con Carlos Ianni (1982). Participó en Ex-Presiones'83 en el Centro Cultural Recoleta. En 1984 Realizó su primera exposición en la galería de Julia Lublin, y estrenó su segunda obra teatral en colaboración con Carlos Ianni, El Mar Dulce y pintó la serie del mismo nombre. En 1985 realizó su primera muestra en la Galería Elizabeth Franck, Bélgica, y junto al grupo La nueva imagen, participó en el XVIII Bienal de San Pablo, donde presentó las cuatro obras de la serie Yo, como... y en la Galería del Retiro, con su serie Siete últimas canciones realizó su última muestra individual en la Argentina hasta casi 20 años después.\r\nNadie olvida nada, \"Ese año pasaba de todo en la Argentina y le dije adiós a lo que había hecho antes. Fue un movimiento de mucha introspección e intensidad\". Entonces surgió la serie Nadie olvida nada, germen de lo que vino después y núcleo del que parten sus muestras antológicas.[7]​";

            listaEventos.Add(e3);

            Eventos e4 = new Eventos();
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
            e4.valor = 20000;
            e4.DescripcionDetallada = "En el año 1981 mudó su taller a la calle Cangallo al 2300 donde trabajó hasta 1993. Allí pintó la serie Nadie olvida nada, que recibió el Premio al Artista Joven del Año de la Asociación Argentina de Críticos de Arte y el Premio del Café Einstein. También dirigió su primer espectáculo teatral junto con Carlos Ianni (1982). Participó en Ex-Presiones'83 en el Centro Cultural Recoleta. En 1984 Realizó su primera exposición en la galería de Julia Lublin, y estrenó su segunda obra teatral en colaboración con Carlos Ianni, El Mar Dulce y pintó la serie del mismo nombre. En 1985 realizó su primera muestra en la Galería Elizabeth Franck, Bélgica, y junto al grupo La nueva imagen, participó en el XVIII Bienal de San Pablo, donde presentó las cuatro obras de la serie Yo, como... y en la Galería del Retiro, con su serie Siete últimas canciones realizó su última muestra individual en la Argentina hasta casi 20 años después.\r\nNadie olvida nada, \"Ese año pasaba de todo en la Argentina y le dije adiós a lo que había hecho antes. Fue un movimiento de mucha introspección e intensidad\". Entonces surgió la serie Nadie olvida nada, germen de lo que vino después y núcleo del que parten sus muestras antológicas.[7]​";
            listaEventos.Add(e4);

            Eventos e5 = new Eventos();
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
            e5.valor = 10000;
            e5.DescripcionDetallada = "En el año 1981 mudó su taller a la calle Cangallo al 2300 donde trabajó hasta 1993. Allí pintó la serie Nadie olvida nada, que recibió el Premio al Artista Joven del Año de la Asociación Argentina de Críticos de Arte y el Premio del Café Einstein. También dirigió su primer espectáculo teatral junto con Carlos Ianni (1982). Participó en Ex-Presiones'83 en el Centro Cultural Recoleta. En 1984 Realizó su primera exposición en la galería de Julia Lublin, y estrenó su segunda obra teatral en colaboración con Carlos Ianni, El Mar Dulce y pintó la serie del mismo nombre. En 1985 realizó su primera muestra en la Galería Elizabeth Franck, Bélgica, y junto al grupo La nueva imagen, participó en el XVIII Bienal de San Pablo, donde presentó las cuatro obras de la serie Yo, como... y en la Galería del Retiro, con su serie Siete últimas canciones realizó su última muestra individual en la Argentina hasta casi 20 años después.\r\nNadie olvida nada, \"Ese año pasaba de todo en la Argentina y le dije adiós a lo que había hecho antes. Fue un movimiento de mucha introspección e intensidad\". Entonces surgió la serie Nadie olvida nada, germen de lo que vino después y núcleo del que parten sus muestras antológicas.[7]​";
            listaEventos.Add(e5);



            return listaEventos;
        }

    }
}
