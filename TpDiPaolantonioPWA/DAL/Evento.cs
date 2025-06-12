using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Evento
{
    public int Id { get; set; }

    public string NombreEvento { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int AutorId { get; set; }

    public int SalaId { get; set; }

    public string Portada { get; set; } = null!;

    public int TipoId { get; set; }

    public double Valor { get; set; }

    public string DescripcionDetalle { get; set; } = null!;

    public virtual Autor Autor { get; set; } = null!;

    public virtual Sala Sala { get; set; } = null!;

    public virtual TipoEvento Tipo { get; set; } = null!;
}
