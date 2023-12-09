using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class Habitacione
{
    public long Id { get; set; }

    public decimal? CostoBase { get; set; }

    public decimal? Impuesto { get; set; }

    public string? TipoHabitacion { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Estado { get; set; }
    public long? CantidadPersonas { get; set; }

    public virtual ICollection<HotelXHabitacion> HotelXHabitacions { get; set; } = new List<HotelXHabitacion>();

    public virtual ICollection<ReservaHabitacion> ReservaHabitacions { get; set; } = new List<ReservaHabitacion>();
}
