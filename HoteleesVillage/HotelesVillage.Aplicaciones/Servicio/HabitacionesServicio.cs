using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelesVillage.Dominio.Modelos;
using HotelesVillage.Aplicaciones.Interfaces;
using HotelesVillage.Dominio.Interfaces;

namespace HotelesVillage.Aplicaciones.Servicio
{
    public class HabitacionesServicio : IServicioHabitaciones
    {

        private readonly IRepositorioHabitaciones<Habitacione> _repoHabitacion;

        public HabitacionesServicio(IRepositorioHabitaciones<Habitacione> repoHabitacion)
        {
            _repoHabitacion= repoHabitacion;
        }


        public async Task<Habitacione> CreateAsync(Habitacione modelo)
        {
            if (modelo == null)  throw new ArgumentNullException("El 'habitaciones' no existe");

            return await _repoHabitacion.CreateAsync(modelo);

        }

        public async void DeshabilitadAsync(long? idHabitacion)
        {
            if (idHabitacion == null)
                throw new ArgumentNullException("El código de la habitacion es null");

          await Task.Run(()=> _repoHabitacion.DeshabilitadAsync(idHabitacion));
        }

        public async Task<Habitacione> EditAsync(Habitacione modelo)
        {
            return await _repoHabitacion.EditAsync(modelo);
        }

        public async Task<IQueryable<Habitacione>> ListarHabitacionesAsync()
        {
            return await _repoHabitacion.ListarHabitacionesAsync();
        }

        public async Task<IQueryable<Habitacione>> SeleccionarHabitacionxHotelAsync(long? idHotel)
        {
            return await _repoHabitacion.SeleccionarHabitacionxHotelAsync(idHotel);
        }
    }
}
