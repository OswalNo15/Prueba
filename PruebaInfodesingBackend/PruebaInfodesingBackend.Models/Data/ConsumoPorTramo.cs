using System;
using System.Collections.Generic;

namespace PruebaInfodesingBackend.Models.Data;

public partial class ConsumoPorTramo
{
    public long IdConsumoxTramo { get; set; }

    public long? CodLinea { get; set; }

    public long? ConsumoResidencialWh { get; set; }

    public long? ConsumoComercialWh { get; set; }

    public long? ConsumoIndustrialWh { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Linea? oLinea { get; set; }
}
