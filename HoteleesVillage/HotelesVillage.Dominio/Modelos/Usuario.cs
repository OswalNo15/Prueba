using System;
using System.Collections.Generic;

namespace HotelesVillage.Dominio.Modelos;

public partial class Usuario
{
    public long Id { get; set; }

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? IdGenero { get; set; }

    public string? Email { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string? TelefonoContacto { get; set; }

    public string? PrimerNombreEmergencia { get; set; }

    public string? SegundoNombreEmergencia { get; set; }

    public string? PrimerApellidoEmergencia { get; set; }

    public string? SegundoApellidoEmergencia { get; set; }

    public string? TelefonoContactoEmergencia { get; set; }

    public bool? Estado { get; set; }

    public virtual TipoGenero? IdGeneroNavigation { get; set; }

    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<ReservaHabitacion> ReservaHabitacions { get; set; } = new List<ReservaHabitacion>();
}
