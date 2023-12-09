using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class Hotel
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<HotelXHabitacion> HotelXHabitacions { get; set; } = new List<HotelXHabitacion>();
}
