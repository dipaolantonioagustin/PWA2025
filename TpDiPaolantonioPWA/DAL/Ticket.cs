using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpDiPaolantonioPWA.DAL;

public partial class Ticket
{
    [Key]
    public int Id { get; set; }
    public int TempId { get; set; }
    public int IdEvento { get; set; }

    public int CantEntradas { get; set; }

    public double ValorTotal { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    //public int Id_usuario { get; set; }

    //public Usuario Usuario { get; set; }
}
