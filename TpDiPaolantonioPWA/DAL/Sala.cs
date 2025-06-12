using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Sala
{
    public int Id { get; set; }

    public string NombreSala { get; set; } = null!;

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
