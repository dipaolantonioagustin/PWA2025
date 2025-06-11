using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Ticket
{
    public int Id { get; set; }

    public int IdEvento { get; set; }

    public int CantEntradas { get; set; }

    public double ValorTotal { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;
}
