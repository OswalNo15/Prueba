using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class TipoGenero
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
