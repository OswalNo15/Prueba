using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Dominio.Modelos.DTO
{
    public class HotelDTO
    {

        [Required]
        [MaxLength(150)]
        [NotMapped]
        public string? Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        [NotMapped]
        public string? Ubicacion { get; set; }


        [Required]
        [NotMapped]
        public bool? Estado { get; set; }

    }
}
