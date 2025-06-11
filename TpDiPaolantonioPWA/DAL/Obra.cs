using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Obra
{
    public int Id { get; set; }

    public string NombreObra { get; set; } = null!;

    public DateOnly FechaObra { get; set; }

    public byte[] ImagenObra { get; set; } = null!;

    public int IdAutor { get; set; }

    public virtual Autor IdAutorNavigation { get; set; } = null!;
}
