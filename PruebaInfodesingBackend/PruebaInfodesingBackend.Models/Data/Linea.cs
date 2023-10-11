using System;
using System.Collections.Generic;

namespace PruebaInfodesingBackend.Models.Data;

public partial class Linea
{
    public long CodLinea { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<ConsumoPorTramo> ConsumoPorTramos { get; set; } = new List<ConsumoPorTramo>();

    public virtual ICollection<CostoPorTramo> CostoPorTramos { get; set; } = new List<CostoPorTramo>();

    public virtual ICollection<PerdidasPorTramo> PerdidasPorTramos { get; set; } = new List<PerdidasPorTramo>();
}
