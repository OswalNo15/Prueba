using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class HotelXHabitacion
{
    public long Id { get; set; }

    public long? IdHotel { get; set; }

    public long? IdHabitaciones { get; set; }

    public bool? Estado { get; set; }

    public virtual Habitacione? oHabitaciones { get; set; }

    public virtual Hotel? oHotel { get; set; }
}
