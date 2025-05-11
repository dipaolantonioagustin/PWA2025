using System.ComponentModel.DataAnnotations.Schema;

namespace TpDiPaolantonioPWA.Models
{
    public class Info
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string descripcion {  get; set; }
        public string img {  get; set; }


        public List<Info> listadoInfo()
        {
            List<Info> li = new List<Info>();

            li.Add(new Info { id = 1, nombre = "Historia MALBA", img = "img/planohistoricomalaba.jpg", descripcion = "El Museo de Arte Latinoamericano de Buenos Aires (Malba) – Fundación Costantini, más conocido simplemente como MALBA es un museo argentino fundado en septiembre de 2001.[1]​ Fue creado con el objetivo de coleccionar, preservar, estudiar y difundir el arte latinoamericano desde principios del siglo xx hasta la actualidad.[2]​ Es una institución privada sin fines de lucro que conserva y exhibe un patrimonio de aproximadamente 400 obras de los principales artistas modernos y contemporáneos de la región.\r\n\r\nEl Malba combina un calendario de exposiciones temporales, con la exhibición estable de su colección institucional, y funciona simultáneamente como un espacio plural de producción de actividades culturales y educativas. Ofrece ciclos de cine, literatura y diseño y lleva adelante una tarea de educativa a través de programas destinados a diferentes tipos de públicos.\r\n\r\nEn mayo de 2007, el Malba fue declarado Sitio de Interés Cultural por parte de la Legislatura de la Ciudad Autónoma de Buenos Aires, y en noviembre de 2008 recibió el Premio Konex de Platino como Mejor entidad cultural de la última década." });
            li.Add(new Info { id = 2, nombre = "Misión", img = "img/mision.jpg", descripcion = " La misión del Museo de Arte Latinoamericano de Buenos Aires (MALBA) es preservar, difundir y poner en valor el arte moderno y contemporáneo de América Latina. A través de exposiciones, programas educativos, actividades culturales y publicaciones, el museo busca generar un espacio de encuentro entre el público y las obras, promoviendo el conocimiento, la reflexión y el diálogo sobre la riqueza artística de la región. MALBA se dedica a la conservación del patrimonio artístico latinoamericano, así como a la investigación y promoción de nuevas perspectivas culturales." });
            li.Add(new Info { id = 3, nombre = "Equipo", img = "img/equipo.jpg", descripcion = "El Museo de Arte Latinoamericano de Buenos Aires (Malba) – Fundación Costantini, más conocido simplemente como MALBA es un museo argentino fundado en septiembre de 2001.[1]​ Fue creado con el objetivo de coleccionar, preservar, estudiar y difundir el arte latinoamericano desde principios del siglo xx hasta la actualidad.[2]​ Es una institución privada sin fines de lucro que conserva y exhibe un patrimonio de aproximadamente 400 obras de los principales artistas modernos y contemporáneos de la región.\r\n\r\nEl Malba combina un calendario de exposiciones temporales, con la exhibición estable de su colección institucional, y funciona simultáneamente como un espacio plural de producción de actividades culturales y educativas. Ofrece ciclos de cine, literatura y diseño y lleva adelante una tarea de educativa a través de programas destinados a diferentes tipos de públicos.\r\n\r\nEn mayo de 2007, el Malba fue declarado Sitio de Interés Cultural por parte de la Legislatura de la Ciudad Autónoma de Buenos Aires, y en noviembre de 2008 recibió el Premio Konex de Platino como Mejor entidad cultural de la última década." });

            return li;
        }

    }


        
    }
