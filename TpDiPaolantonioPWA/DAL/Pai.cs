using System;
using System.Collections.Generic;

namespace TpDiPaolantonioPWA.DAL;

public partial class Pai
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Autor> Autors { get; set; } = new List<Autor>();
}
