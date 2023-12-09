using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class ViewSearchHotelxHabitacion
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? UbicacionHotel { get; set; }

    public DateTime? FechaCheckin { get; set; }

    public DateTime? FechaCheckout { get; set; }

    public string?  UbicacionHabitacion { get; set; }

    public long? CantidadPersonas { get; set; }
}
