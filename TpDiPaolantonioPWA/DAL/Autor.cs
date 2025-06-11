using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Autor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? NacionalidadId { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual Pai? Nacionalidad { get; set; }

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
