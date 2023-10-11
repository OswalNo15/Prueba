using System;
using System.Collections.Generic;

namespace PruebaInfodesingBackend.Models.Data;

public partial class PerdidasPorTramo
{
    public long IdPerdidaxTramo { get; set; }

    public long? CodLinea { get; set; }

    public string? PerdidaResidencialPorcentaje { get; set; }

    public string? PerdidaComercialPorcentaje { get; set; }

    public string? PerdidaIndustrialPorcentaje { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Linea? oLinea { get; set; }
}
