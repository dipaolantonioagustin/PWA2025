namespace TpDiPaolantonioPWA.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string autor { get; set; }

        public DateTime fecha { get; set; }
        public string imagen { get; set; }

       public List<Obra> ListarObras()
        {
            List<Obra> obras = new List<Obra>();

            obras.Add(new Obra() { Id = 1, autor ="Rafael Barradas", fecha= new DateTime(1918,05,05), nombre="Quiosco de Canaletas", imagen= "/img/ColeccionPermanente/barradas.jpg" });
            obras.Add(new Obra() { Id = 2, autor = "Antonio Berni", fecha = new DateTime(1934, 06, 02), nombre = "Manifestación", imagen = "/img/ColeccionPermanente/berni.jpg" });
            obras.Add(new Obra() { Id = 3, autor = "Jorge de La Vega", fecha = new DateTime(1969, 10, 05), nombre = "Rompecabezas", imagen = "/img/ColeccionPermanente/de la vega.jpg" });
            obras.Add(new Obra() { Id = 4, autor = "Firda Kahlo", fecha = new DateTime(1942, 05, 05), nombre = "Autoretrato con Chango y Loro", imagen = "/img/ColeccionPermanente/Frida.jpg" });
            obras.Add(new Obra() { Id = 5, autor = "Gyula Kosice", fecha = new DateTime(1944, 12, 05), nombre = "Ranyi Na", imagen = "/img/ColeccionPermanente/gyula.jpg" });
            obras.Add(new Obra() { Id = 6, autor = "Martins", fecha = new DateTime(1945, 11, 05), nombre = "O Imposible", imagen = "/img/ColeccionPermanente/martins.jpg" });
            obras.Add(new Obra() { Id = 7, autor = "Trasila Do Amaral", fecha = new DateTime(1928, 05, 05), nombre = "Abaporu", imagen = "/img/ColeccionPermanente/tarsila do amaral.jpg" });
            obras.Add(new Obra() { Id = 8, autor = "Xul solar", fecha = new DateTime(1923, 05, 05), nombre = "Pareja", imagen = "/img/ColeccionPermanente/xuls.jpg" });
            obras.Add(new Obra() { Id = 8, autor = "Diego Rivera", fecha = new DateTime(1940, 05, 05), nombre = "Retrato de Ramón Gomez de La Serna", imagen = "/img/ColeccionPermanente/rivera.jpg" });

            return obras;

        }







    }
}
