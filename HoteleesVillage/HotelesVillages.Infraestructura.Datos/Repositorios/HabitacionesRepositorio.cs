using HotelesVillage.Dominio.Interfaces;
using HotelesVillage.Dominio.Modelos;
using HotelesVillages.Infraestructura.Datos.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelesVillages.Infraestructura.Datos.Repositorios
{
    public class HabitacionesRepositorio : IRepositorioHabitaciones<Habitacione>
    {
        private readonly HotelesContext _dbContextHotel;

        public HabitacionesRepositorio(HotelesContext dbContextHotel)
        {
            _dbContextHotel = dbContextHotel;
        }
        public async Task<Habitacione> CreateAsync(Habitacione modelo)
        {
            if (modelo == null)
            {
                throw new ArgumentNullException("El 'habitaciones' no existe");
            }

            _dbContextHotel.Habitaciones.Add(modelo);
            await _dbContextHotel.SaveChangesAsync();
            return modelo;
        }

        public async void DeshabilitadAsync(long? idHabitacion)
        {
            var habitacioneReturn = await _dbContextHotel.Habitaciones.FindAsync(idHabitacion);
            
            if (habitacioneReturn == null) 
                throw new ArgumentNullException("El no existe el habitación que intentas buscar");

            habitacioneReturn.Estado = false;

            _dbContextHotel.Habitaciones.Update(habitacioneReturn);
            await _dbContextHotel.SaveChangesAsync();

        }

        public async Task<Habitacione> EditAsync(Habitacione modelo)
        {
            _dbContextHotel.Habitaciones.Update(modelo);
            await _dbContextHotel.SaveChangesAsync();
            return modelo;
        }

        public async Task<IQueryable<Habitacione>> ListarHabitacionesAsync()
        {
            IQueryable<Habitacione> queryHabitacionesTotal = _dbContextHotel.Habitaciones;
            return queryHabitacionesTotal;

        }

        public async Task<IQueryable<Habitacione>> SeleccionarHabitacionxHotelAsync(long? idHotel)
        {
            var ListadoHabitaciones = await (from Habitaciones in _dbContextHotel.Habitaciones
                                             join hotelxhabitacion in _dbContextHotel.HotelXHabitacions on Habitaciones.Id equals hotelxhabitacion.IdHabitaciones
                                             join Hote in _dbContextHotel.Hotels on hotelxhabitacion.IdHotel equals Hote.Id
                                             join reservaLeft in _dbContextHotel.ReservaHabitacions on Habitaciones.Id equals reservaLeft.IdHabitacion into ReservaHabitacioneLeft
                                             from Reserva in ReservaHabitacioneLeft.DefaultIfEmpty()
                                             where Habitaciones.Estado == true && hotelxhabitacion.Estado == true && Hote.Estado == true &&
                                             (Reserva.FechaCheckin < DateTime.Now || Reserva.FechaCheckout > DateTime.Now
                                             || Reserva.FechaCheckin == null || Reserva.FechaCheckout == null)

                                             select new Habitacione
                                             {
                                                 Id = Habitaciones.Id,
                                                 Ubicacion = Habitaciones.Ubicacion,
                                                 CantidadPersonas = Habitaciones.CantidadPersonas,
                                                 CostoBase = Habitaciones.CostoBase,
                                                 Impuesto = Habitaciones.Impuesto,
                                                 TipoHabitacion = Habitaciones.TipoHabitacion,
                                             }
                                             ).ToListAsync();

            return ListadoHabitaciones.AsQueryable();
        }
    }
}
