using HotelesVillage.Dominio.Interfaces;
using HotelesVillage.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillage.Aplicaciones.Interfaces
{
    public interface IServicioHabitaciones
    {
        Task<Habitacione> CreateAsync(Habitacione modelo);
        Task<Habitacione> EditAsync(Habitacione modelo);
        void DeshabilitadAsync(long? idHabitacion);

        Task<IQueryable<Habitacione>> ListarHabitacionesAsync();
        Task<IQueryable<Habitacione>> SeleccionarHabitacionxHotelAsync(long? idHotel);
       
    }
}
