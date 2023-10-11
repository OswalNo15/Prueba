using System;
using System.Collections.Generic;

namespace PruebaInfodesingBackend.Models.Data;

public partial class CostoPorTramo
{
    public long IdCostoxTramo { get; set; }

    public long? CodLinea { get; set; }

    public string? CostoResidencialWh { get; set; }

    public string? CostoComercialWh { get; set; }

    public string? CostoIndustrialWh { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Linea? oLinea { get; set; }
}
