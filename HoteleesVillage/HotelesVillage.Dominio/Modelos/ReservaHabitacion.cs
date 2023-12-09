using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class ReservaHabitacion
{
    public long Id { get; set; }

    public long? IdHabitacion { get; set; }

    public long? IdUsuario { get; set; }

    public DateTime? FechaCheckin { get; set; }

    public DateTime? FechaCheckout { get; set; }

    public bool? ServicioCancelado { get; set; }

    public string? ObservacionCancelado { get; set; }

    public virtual Habitacione? IdHabitacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
