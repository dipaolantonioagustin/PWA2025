using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpDiPaolantonioPWA.DAL;

public partial class Evento
{
    public int Id { get; set; }
    
    [Required (ErrorMessage ="Ingresar el Nombre del Evento")]
    public string NombreEvento { get; set; } = null!;

    [Required(ErrorMessage = "Ingresar Descripcion")]
    public string Descripcion { get; set; } = null!;
    [Required(ErrorMessage = "Ingresar fecha Inicio")]
    public DateTime FechaInicio { get; set; }
    
    [Required(ErrorMessage = "Ingresar fecha Fin")]
    public DateTime FechaFin { get; set; }

    [Required(ErrorMessage = "Ingresar Autor del Evento")]
    [Range(1, int.MaxValue, ErrorMessage ="Ingrese un Autor")]
    public int AutorId { get; set; }

    [Required(ErrorMessage = "Ingresar sala")]
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese una Sala")]
    public int SalaId { get; set; }

    [Required(ErrorMessage = "Cargar Foto Portada")]
    public string Portada { get; set; } = null!;

    [Required(ErrorMessage = "Ingresar Tipo de Evento")]
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese una Tipo")]
    public int TipoId { get; set; }
    
    [Required(ErrorMessage = "Ingresar Valor")]
    [Range(1, int.MaxValue, ErrorMessage = "Ingrese un Valor")]
    public double Valor { get; set; }

    [Required(ErrorMessage = "Ingresar Descripcion Detalle")]
    public string DescripcionDetalle { get; set; } = null!;

  //  [Required(ErrorMessage = "Ingresar Autor del Evento")]
    public virtual Autor Autor { get; set; } = null!;
    
   // [Required(ErrorMessage = "Ingresar Sala del Evento")]
    public virtual Sala Sala { get; set; } = null!;
   
  //  [Required(ErrorMessage = "Ingresar Tipo del Evento")]
    public virtual TipoEvento Tipo { get; set; } = null!;
}
