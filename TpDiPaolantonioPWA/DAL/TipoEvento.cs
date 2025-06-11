using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class TipoEvento
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
